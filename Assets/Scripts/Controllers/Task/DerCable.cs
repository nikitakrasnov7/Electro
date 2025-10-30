using UnityEngine;

public class DerCable : AbstractTask
{
    bool isHand = false;

    public override void FinishMission()
    {

    }

    public override void StartMission()
    {
        transform.GetChild(0).gameObject.SetActive(true);

    }

    public override bool TrackingMission()
    {
        if (isActive)
        {
            if (isHand)
            {

                 transform.GetChild(0).transform.position = GameManager.playerPosition;
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public void Uping()
    {
        isHand = true;
    }

}
