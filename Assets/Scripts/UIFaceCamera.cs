using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCamera : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPoint = cam.transform.position;

        // project camera position onto xz plane
        targetPoint.y = transform.position.y;

        // Vector3.up is a normal of the xz plane
        transform.LookAt(targetPoint, Vector3.up);
    }
}
