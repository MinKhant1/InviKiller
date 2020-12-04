using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaskAI : MonoBehaviour
{

    [SerializeField] AiTask currentTask;
    NavMeshAgent agent;
    Animator anim;

    bool waited;

    bool doingTask;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!doingTask && pathComplete())
        {
            waited = false;
        }

        if (doingTask && pathComplete())
        {
            anim.SetBool(currentTask.animationName, true);
            if (!waited)
            {
                StartCoroutine(TaskWait());
                waited = true;
            }


        }


        if (currentTask != null)
        {
            doingTask = true;
            agent.SetDestination(currentTask.target.position);

        }
        else
        {
            doingTask = false;

        }

    }

    IEnumerator TaskWait()
    {
        yield return new WaitForSeconds(currentTask.duration);
        anim.SetBool(currentTask.animationName, false);


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
}
