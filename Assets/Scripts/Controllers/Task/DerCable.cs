using UnityEngine;

public class DerCable : AbstractTask
{
    public static bool isHand = false;
    static GameObject Cabel;

    public override void FinishMission()
    {
        isActive = false;
        isComplete = true;

    }

    public override void StartMission()
    {
        isActive = true;
        isComplete = false;

        if (!isHand)
        {
            Cabel = transform.GetChild(0).gameObject;
            Cabel.SetActive(true);

        }
    }

    public override bool TrackingMission()
    {
        if (isActive && Cabel != null)
        {
            if (isHand)
            {

                Cabel.transform.GetChild(1).position = MovementPlayer.HandPosition.position;
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
        isActive = false;

    }

    public void ConnectionCabel()
    {
        Cabel.transform.GetChild(1).transform.position = gameObject.transform.GetChild(1).position;
        Cabel = null;
    }
}
