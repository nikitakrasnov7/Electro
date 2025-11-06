using UnityEngine;

public class DerCable : AbstractTask
{
    public static bool isHand = false;
    static GameObject Cabel;

    public override void FinishMission()
    {
        isActive = false; 
        isComplete = true;
        Debug.Log("Finish TASK");
    }

    public override void StartMission()
    {
        isActive = true; 
        isComplete = false; 
        

        Cabel = transform.GetChild(0).gameObject;
        Cabel.SetActive(true);

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

    }
    
    public void ConnectionCabel()
    {
        isHand = false; 
        Cabel.transform.GetChild(1).transform.position = gameObject.transform.GetChild(1).position;
        Cabel = null;
    }
}
