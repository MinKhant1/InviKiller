using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FootStepObjSpawner : MonoBehaviour
{

    [SerializeField] GameObject footStepObj;
    [SerializeField] GameObject[] footStepParticle;
    [SerializeField] FootStepEmitter emitter;
    bool activated;
    IEnumerator fsEmitting;
    // Start is called before the first frame update
    void Start()
    {
        footStepParticle = GameObject.FindGameObjectsWithTag("FootStep");
        emitter = GetComponent<FootStepEmitter>();
        fsEmitting = spawnFootStepDector();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject fs in footStepParticle)
        {
            if (fs.active == true && gameObject.GetComponent<Rigidbody>().velocity !=Vector3.zero) 
            {
               if(!activated)
                {
                    StartCoroutine(fsEmitting);
                    activated = true;
                    
                }
                break;
            }
            else
            {
                StopCoroutine(fsEmitting);
                activated = false;
            }

        }
        
    }

    IEnumerator spawnFootStepDector()
    {
        while(true)
        {
            yield return new WaitForSeconds(emitter.delta);
            Instantiate(footStepObj, transform.position, transform.rotation);

        }
       

    }
}
