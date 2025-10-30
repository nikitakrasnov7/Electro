using UnityEngine;

public class DerCable : AbstractTask
{
    public override void FinishMission()
    {
        
    }

    public override void StartMission()
    {
        gameObject.SetActive(true);
    }

    public override bool TrackingMission()
    {
        return false;
    }

    
}
