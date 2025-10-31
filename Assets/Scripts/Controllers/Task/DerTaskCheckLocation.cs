using System;
using UnityEngine;
using UnityEngine.UI;
public class DerTaskCheckLocation :AbstractTask
{

    public static int CountTriggersZone;
   
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
        CountTriggersZone = FindObjectsOfType<TriggersForCheckLocation>().Length;
       


    }

    public override bool TrackingMission()
    {
       
        if (CountTriggersZone == 0)
        {
            
            return true;    
        }
        return false;
    }
    public static void EnterToTriggerZoneLocation()
    {
        CountTriggersZone--;
    }
}
