using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPush : MonoBehaviour
{
    public float offset;
    Animator anim;
    // Start is called before the first frame update
   
    void MoveFrontWithOffset()
    {
        transform.position += Vector3.forward * offset;
    }
}
