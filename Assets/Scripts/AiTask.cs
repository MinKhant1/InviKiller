
using UnityEngine;

[System.Serializable]
public class AiTask
{
    public string name;
    public Transform target;
    public float duration;
    public bool active = false;
    public string animationName;
    public bool queued = false;
    public TaskAssignScript taskScript;



}
