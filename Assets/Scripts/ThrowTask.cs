using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTask : TaskAssignScript
{
    public GameObject throwObj;
    public Vector3 normalPositon;
    public Quaternion normalRotation;
    
  
    // Start is called before the first frame update
    void Start()
    {
        normalPositon = throwObj.transform.position;
        normalRotation = throwObj.transform.rotation;
        
    }

    // Update is called once per frame
 public override  void Update()
    {
        base.Update();
    }
    public override void ActivateTask()
    {

        base.ActivateTask();
        throwObj.GetComponent<Rigidbody>().isKinematic = false;
        throwObj.GetComponent<Rigidbody>().AddForce(transform.right * 5, ForceMode.Impulse);
    }
    
    

    public override void DeActivateTask()
{
        base.DeActivateTask();
        throwObj.GetComponent<Rigidbody>().isKinematic = true;
        throwObj.transform.position = normalPositon;
        throwObj.transform.rotation = normalRotation;
     
    }

}
