using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WifeSense : AiSense
{

    [SerializeField] AiTask callPolice;
    [SerializeField] TaskBasedAi tbAi;
    [SerializeField] AiTask phoneTask;
    [SerializeField] AIData aIData;

    bool called;
   


    // Start is called before the first frame update
    public override void Start()
    {
        if (!sitting)
            base.Start();
    }


    public override void Update()
    {
        base.Update();

        if (!sitting)
            SpecialTask();

      
        if(aIData.currentState==EnemyStates.Noticed && pathComplete())
        {
            Debug.Log("complete");
            anim.SetTrigger("Wtf");
            StartCoroutine(CalledTrue());
        }
        if(called & pathComplete())
        {
            FacePlayer();
        }

    }

    public IEnumerator CalledTrue()
    {
        yield return new WaitForSeconds(3);
        called = true;
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    public override IEnumerator Alert(int lvl)
    {
        if (!sitting)
        {



            agent.speed = 0;
            anim.SetTrigger("Wtf");
            alertprocess = true;
            Debug.Log("Alert start");
            yield return new WaitForSeconds(2);

            wifeData.currentAlertCount += lvl;

            if (wifeData.currentAlertCount < wifeData.MaxAlertCount)
            {
                wifeData.currentState = EnemyStates.Normal;
            }
            else
            {
                Noticed();
            }
            alertprocess = false;

        }

    }


    protected override void Noticed()
    {
        wifeData.currentState = EnemyStates.Noticed;

    }

    public override IEnumerator NoticedTask()
    {
        Debug.Log("NoticeTask Started");

        agent.SetDestination(phoneTask.target.position);
        //if (pathComplete())
        //{
        //    Debug.Log("com");
        //    anim.SetTrigger("Wtf");
        //    yield return new WaitForSeconds(3);
        //    called = true;
        //    Debug.Log("Phoned");
        //}


        yield return new WaitUntil(() => called);
        wifeData.currentState = EnemyStates.Attacking;



    }

    //public override void SpecialTask()
    //{
    //    if (phoneTask.active)
    //    {
    //        Debug.Log("Added");
    //        if (!phoneTask.queued)
    //        {
    //            Debug.Log("Queued");
    //            tbAi.onGoingTasks.Add(phoneTask);

    //            phoneTask.active = false;
    //        }

    //    }
    //}
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

    public override void SpecialTask()
    {
       
    }
    public void StopAgent()
    {
        agent.speed = 0;

    }
    public void MoveAgain()
    {
        agent.speed = moveSpeed;
    }
    public void FacePlayer()
    {
        Vector3 lookDir = player.transform.position - transform.position;
        lookDir.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1f);
    }
}
