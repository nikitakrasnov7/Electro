
using UnityEngine;

public abstract class AbstractTask:MonoBehaviour
{
    public bool isActive { get; set; }
    public bool isComplete { get; set; }

    public abstract void StartMission();

    public abstract bool TrackingMission();
    public abstract void FinishMission();

}