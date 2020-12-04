using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDraggable : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<DragCorpse>().draggable = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<DragCorpse>().draggable = false;
        }
    }
}
