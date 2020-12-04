using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunShoot : MonoBehaviour
{
    [SerializeField] UbhNwayShot waysShot;
    [SerializeField] UbhShotCtrl shotCtrl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waysShot._CenterAngle = -transform.rotation.eulerAngles.y;
    }
  public void WayShot()
    {
        shotCtrl.StartShotRoutine();
     
    }
}
