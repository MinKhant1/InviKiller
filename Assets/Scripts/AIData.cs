using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIData : MonoBehaviour
{
    string aiName;
    public EnemyStates currentState = EnemyStates.Normal;
    public int MaxAlertCount;
    public int currentAlertCount;
}
