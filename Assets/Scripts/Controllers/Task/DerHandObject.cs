using UnityEngine;

public class DerHandObject : AbstractTask {

    private void OnEnable()
    {
        isActive = true;
    }

    public void Drag()
    {

        gameObject.transform.position = MovementPlayer.HandPosition.position;
        gameObject.transform.SetParent(MovementPlayer.HandPosition);
    }
    public override void FinishMission()
    {
        isComplete = true;
        isActive = false;
    }

    public override void StartMission()
    {
        isActive = true;
        isComplete = false;
    }

    public override bool TrackingMission()
    {
        return false;
    }

   
}
