using UnityEngine;

public class DerCable : AbstractTask
{
    bool isHand = false;
    GameObject Cabel;

    public override void FinishMission()
    {
        isActive = false; 
        isComplete = true;
    }

    public override void StartMission()
    {
        isActive = true; 
        isComplete = false; 
        Debug.Log("start Abstract Mission");

        Cabel = transform.GetChild(0).gameObject;
        transform.GetChild(0).gameObject.SetActive(true);

    }

    public override bool TrackingMission()
    {
        if (isActive)
        {
            if (isHand)
            {

                 transform.GetChild(0).GetChild(1).transform.position = MovementPlayer.HandPosition.position;
            }

            return false;
        }
        else
        {
            return true;
        }
    }

    public void Uping()
    {
        isHand = true;

    }

}
