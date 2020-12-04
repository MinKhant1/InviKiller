using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class EnemyMob : MonoBehaviour, IKillable
{


    Animator anim;



    public bool killable;
    bool strangled;
    [SerializeField] EnemyStates currentState;
    GameObject player;

    [SerializeField] Image killImage;
    [Header("Enemy Sprites")]
    [SerializeField] Sprite strangledSprite;

    public GameObject deadRagdoll;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        currentState = EnemyStates.Normal;




    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyStates.Normal:
                killImage.sprite = strangledSprite;
                break;
            case EnemyStates.Disabled:

                break;
            case EnemyStates.Noticed:
                break;
            case EnemyStates.Attacking:
                break;
            case EnemyStates.Dead:
                killImage.enabled = false;
                break;
            default:
                break;
        }
        if (currentState == EnemyStates.Disabled)
        {
            killImage.enabled = false;
        }
        else
        {
            killImage.enabled = true;
        }
        if (killable)
        {
            ShowUI();
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentState = EnemyStates.Disabled;
                Strangled(transform.position - player.transform.position);
            }
            if (Input.GetKeyUp(KeyCode.E) && currentState == EnemyStates.Disabled)
            {
                ReleaseStrangled();
            }
        }
        else
        {
            HideUI();
        }


    }
    public void ShowUI()
    {
        killImage.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 0.3f);
    }

    public void HideUI()
    {
        killImage.transform.DOScale(Vector3.zero, 0.3f);
    }

    public void Strangled(Vector3 dir)
    {

        transform.rotation = Quaternion.LookRotation(dir);
        currentState = EnemyStates.Disabled;
        anim.SetBool("Strangled", true);




    }
    public void ReleaseStrangled()
    {
        anim.SetBool("Strangled", false);
        currentState = EnemyStates.Noticed;
    }
    



    public void ChangeToDead()
    {

        currentState = EnemyStates.Dead;
        Instantiate(deadRagdoll, transform.position, transform.rotation);


        Destroy(gameObject);

    }

    public void Attack()
    {
        //Vector3 offset=new Vec;
    }
}