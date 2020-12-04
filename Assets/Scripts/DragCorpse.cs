using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCorpse : MonoBehaviour
{
    [SerializeField] GameObject head;
    [SerializeField] Rigidbody[] ragBodies;
    [SerializeField] Collider[] ragColliders;
    GameObject player;
    [HideInInspector] public bool draggable;
    public bool dragged;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ragBodies = GetComponentsInChildren<Rigidbody>();
        ragColliders = GetComponentsInChildren<Collider>();
        foreach (Rigidbody rig in ragBodies)
        {
            if (rig.gameObject.name != this.name)
            {

                rig.isKinematic = true;
            }
        }
        foreach (Collider col in ragColliders)
        {
            if (col.gameObject.name != this.name && col.gameObject.name != "DraggAble")
                col.enabled = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (draggable)
            {
                Drag();



            }


        }

        if (dragged)
        {
            player.GetComponent<PlayerStealthController>().walkState = playerState.Drag;
        }



    }
    public void Drag()
    {

        if (!dragged)
        {

            foreach (Rigidbody rig in ragBodies)
            {
                if (rig.gameObject.name != this.name)
                {
                    rig.isKinematic = false;
                }
            }
            foreach (Collider col in ragColliders)
            {
                if (col.gameObject.name != this.name)
                    col.enabled = true;
            }
            gameObject.GetComponent<Animator>().enabled = false;
            head.AddComponent<HingeJoint>().connectedBody = player.GetComponent<Rigidbody>();
        }
        else
        {

            if (head.GetComponent<HingeJoint>() != null)
                head.GetComponent<HingeJoint>().breakForce = 0;
        }
        dragged = !dragged;


    }

}
