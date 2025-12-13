using UnityEngine;

public class DerOpenDoor : AbstractTask
{
    public bool isOpen;
    public override void FinishMission()
    {
        isComplete = true;
    }

    public override void StartMission()
    {
        isActive = true;
        isComplete = false;
    }

    public override bool TrackingMission()
    {
        if (isOpen)
        {
            return true;

        }
        else
        {

            return false;
        }
    }


}
