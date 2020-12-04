
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenTask : TaskAssignScript
{
    public GameObject fire;


    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void ActivateTask()
    {
        base.ActivateTask();
        fire.SetActive(true);
    }

    public override void DeActivateTask()
    {
        base.DeActivateTask();
        fire.SetActive(false);
    }

}
