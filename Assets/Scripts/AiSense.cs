using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class AiSense : MonoBehaviour
{
    [SerializeField] List<Rigidbody> nearbyObjects;
    [SerializeField] List<Rigidbody> collidedObjs;
    public AIData wifeData;
   public bool alertprocess;


    public NavMeshAgent agent;
   public Animator anim;
    public bool sitting;
    [SerializeField] public float moveSpeed;
    public GameObject player;
    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.speed = moveSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public virtual void Update()
    {
        for (int i = 0; i <= nearbyObjects.Count; i++)
        {
            for (int j = 0; j <= collidedObjs.Count; j++)
            {
                //if(nearbyObjects[i]!=)
            }

        }

        foreach (Rigidbody rigidbody in nearbyObjects)
        {
            if(rigidbody.velocity!=Vector3.zero)
            {
                if(!alertprocess)
                {
                    StartCoroutine(Alert(1));
                }
             
                break;
            }
        }
        if(!sitting)
        {
            if (wifeData.currentAlertCount >= wifeData.MaxAlertCount)
            {
                Noticed();
            }

        }
        
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PhyObj"))
        {
            nearbyObjects.Add(other.attachedRigidbody);
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PhyObj"))
        {
            nearbyObjects.Remove(other.attachedRigidbody);
        }
    }
    public abstract IEnumerator Alert(int lvl);


    protected abstract void Noticed();

    public abstract IEnumerator NoticedTask();

    public abstract void SpecialTask();
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PhyObj"))
        {
            collidedObjs.Add(collision.collider.attachedRigidbody);
            StartCoroutine(RemoveCollided());
        }
    }

    IEnumerator RemoveCollided()
    {
        yield return new WaitForSeconds(3);
        collidedObjs.RemoveAt(collidedObjs.Count-1);
    }


}
