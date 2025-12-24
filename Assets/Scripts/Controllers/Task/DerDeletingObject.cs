using UnityEngine;

public class DerDeletingObject : AbstractTask
{
    public GameObject destroyObj;
    public override void FinishMission()
    {
        isActive = true;
        isComplete = true;
    }

    public override void StartMission()
    {
        isActive = true;
        isComplete = false;
    }

    public override bool TrackingMission()
    {
        if (destroyObj != null) 
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Delete()
    {
        Destroy(destroyObj);
    }
}
