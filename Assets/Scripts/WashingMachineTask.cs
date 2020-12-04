using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WashingMachineTask : TaskAssignScript
{
    public float speed;
    public float amount;
    Tween shakeTween;
    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    
    }
    public override void ActivateTask()
    {
        DOTween.Play("WShake");
        base.ActivateTask();
  
       
    }
    public override void DeActivateTask()
    {
        DOTween.Restart("WShake");
        DOTween.Pause("WShake");
        base.DeActivateTask();
       
    }

    
}
