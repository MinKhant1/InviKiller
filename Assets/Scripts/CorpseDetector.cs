using UnityEngine;

public class CorpseDetector : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



      


    
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Corpse"))
        {
          
            Detect(other);
        }
    }
    public void Detect(Collider corpse)
    {
        RaycastHit hit;
      if(  Physics.Raycast(transform.position,corpse.transform.position-transform.position,out hit))
        {
            if(hit.collider.CompareTag("Wall"))
            {
                Debug.Log("No");
            }

            if(hit.collider.CompareTag("Corpse"))
            {
                Debug.Log("corpse detected");
            }
        }
        
    }

}
