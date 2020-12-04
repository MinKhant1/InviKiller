using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ECM.Controllers;

public class PlayerStealthController : MonoBehaviour
{
    BaseCharacterController charController;

     float walkSpeed;
    float tipToeSpeed;
    [SerializeField] GameObject playerCircle;
 

    public playerState walkState;


 
  
    // Start is called before the first frame update
    void Start()
    {
        walkState = playerState.Normal;
        charController = GetComponent<BaseCharacterController>();
        walkSpeed = charController.speed;
      
    }

    // Update is called once per frame
    void Update()
    {
      
        tipToeSpeed = walkSpeed / 2;
        if(Input.GetKey(KeyCode.C))
        {
            walkState = playerState.TipToe;
            charController.speed = tipToeSpeed;
            playerCircle.transform.DOScale(new Vector3(0.8f,0,0.8f), 0.5f);
        }
        else
        {
            walkState = playerState.Normal;
            charController.speed = walkSpeed;
            playerCircle.transform.DOScale(Vector3.one, 0.5f);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyMob"))
        {
            
            other.GetComponent<EnemyMob>().killable = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyMob"))
        {
          
            other.GetComponent<EnemyMob>().killable = false;
        }
    }
}
