using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskAssignScript : MonoBehaviour
{
    [SerializeField] TaskBasedAi taskBasedAi;
    [SerializeField] int index;
  public  bool interactable;

  public  bool taskActive;

    bool activated;


    public virtual void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!taskBasedAi.tasks[index].active  )
                {
                    taskActive = true;
                    taskBasedAi.tasks[index].active = true;
                  
                }
                    
            }
        }
        if(taskActive)
        {
            if(!activated)
            {
                ActivateTask();
                activated = true;
            }
           
        }
        else
        {
            activated = false;
            DeActivateTask();
        }


    }

    public virtual void ActivateTask()
    {
        interactable = false; 
        transform.GetComponent<SphereCollider>().enabled = false;

    }
    public virtual void DeActivateTask()
    {
        transform.GetComponent<SphereCollider>().enabled = true;

    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable = true;
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable = false;
        }
    }
}
