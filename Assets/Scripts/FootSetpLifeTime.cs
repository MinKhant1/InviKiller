using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSetpLifeTime : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime-1.5f);
        
    }

    
}
