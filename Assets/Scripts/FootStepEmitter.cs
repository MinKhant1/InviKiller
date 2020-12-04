using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepEmitter : MonoBehaviour
{
    Vector3 lastEmit;
    public float delta = 1;
    public float gap = 0.5f;
    int dir = 1;
    public ParticleSystem system;

    public float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(lastEmit, transform.position) > delta)
        {
            var pos = transform.position + new Vector3(0,yOffset,0)+(transform.right * gap * dir);
            dir *= -1;
            ParticleSystem.EmitParams ep = new ParticleSystem.EmitParams();
            ep.position = pos;
            ep.rotation = transform.rotation.eulerAngles.y;
            system.Emit(ep, 1);
            lastEmit = transform.position;
        }
    }
}
