using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaskBasedAi : MonoBehaviour
{


    public AiTask[] tasks;
    public List<AiTask> onGoingTasks = new List<AiTask>();

    [SerializeField] AIData aiData;
    [SerializeField] AiSense aiSense;
    public IEnumerator alertRoutine;

    [SerializeField] Transform home;
    public AiTask currentTask;

    [SerializeField] GameObject aiObject;
    [SerializeField] GameObject sittingObject;
    NavMeshAgent agent;
    bool doTaskStarted;
    bool noticed;
    [SerializeField] AiTask phoneTask;

    Coroutine stopRoutine;


    Animator anim;
    public bool alerting;

    GameObject player;

   

    // Start is called before the first frame update
    void Start()
    {
        agent = aiObject.GetComponent<NavMeshAgent>();
        anim = aiObject.GetComponent<Animator>();
        aiData = GetComponent<AIData>();
        player = GameObject.FindGameObjectWithTag("Player");

       
    }

    // Update is called once per frame
    void Update()
    {
        alerting = aiSense.alertprocess;


        AddTask();

        switch (aiData.currentState)
        {
            case EnemyStates.Normal:
                Task();
                break;
            case EnemyStates.Disabled:
                break;
            case EnemyStates.Noticed:

                if (!noticed)
                {
                    sittingObject.SetActive(false);
                    aiObject.SetActive(true);
                    aiSense.StartCoroutine("NoticedTask");
                    noticed = true;
                }


                break;
            case EnemyStates.Alerted:
                if (!aiSense.alertprocess)
                {

                    aiSense.StartCoroutine(aiSense.Alert(1));

                }
                break;
            case EnemyStates.Attacking:
                agent.stoppingDistance = 5f;
                agent.SetDestination(player.transform.position);
                if (pathComplete())
                {
                    anim.SetTrigger("Shoot");
                }
                break;
            case EnemyStates.Dead:
                break;
            default:
                break;
        }
        if (currentTask == phoneTask && pathComplete())
        {
           
        }

    }

    private void Task()
    {


        if (onGoingTasks.Count > 0)
        {
            aiObject.SetActive(true);
            sittingObject.SetActive(false);
            currentTask = onGoingTasks[0];
            agent.SetDestination(currentTask.target.position);

            if (pathComplete())
            {

                if (!doTaskStarted)
                {
                    Debug.Log("Stopping");
                    stopRoutine = StartCoroutine(Dotask());
                    doTaskStarted = true;


                }


            }
            else
            {
                doTaskStarted = false;

            }
        }
        else
        {
            if (agent.gameObject.active)
            {
                agent.SetDestination(home.position);
            }

            if (pathComplete())
            {
                if (sittingObject != null)
                {
                    aiObject.SetActive(false);
                    sittingObject.SetActive(true);
                }
                Debug.Log("Sit");
            }
        }



    }

    private void AddTask()
    {
        foreach (AiTask task in tasks)
        {
            if (task.active)
            {

                if (!task.queued)
                {
                    onGoingTasks.Add(task);

                    task.active = false;
                }

            }

        }
    }

    public IEnumerator Dotask()
    {
        anim.SetBool(currentTask.animationName, true);

        yield return new WaitForSeconds(currentTask.duration);
        anim.SetBool(currentTask.animationName, false);
        currentTask.taskScript.taskActive = false;
        onGoingTasks.RemoveAt(0);


        Debug.Log("TaskComplete");



    }

    public bool pathComplete()
    {
        if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                return true;
            }
        }

        return false;
    }

    public void Wtf()
    {
        anim.SetTrigger("Wtf");

    }
    public  void SpecialTask()
    {
        if (phoneTask.active)
        {
            Debug.Log("Added");
            if (!phoneTask.queued)
            {
                Debug.Log("Queued");
                onGoingTasks.Add(phoneTask);

                phoneTask.active = false;
            }

        }
    }



}

