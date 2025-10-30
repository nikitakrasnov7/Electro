
using UnityEngine;

public abstract class AbstractTask:MonoBehaviour
{
    public bool isActive { get; set; }
    public bool isComplete { get; set; }

    public virtual void StartMission() { isActive = true; isComplete = false; }

    public abstract bool TrackingMission();
    public virtual void FinishMission() { isActive = false;isComplete = true; }

}