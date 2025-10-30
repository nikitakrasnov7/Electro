using System;
using UnityEngine;
using UnityEngine.UI;
public class DerTaskCheckLocation :AbstractTask
{

    public static int CountTriggersZone;
   
    public override void FinishMission()
    {  
    }

    
    public override void StartMission()
    {
        CountTriggersZone= FindObjectsOfType<TriggersForCheckLocation>().Length;
       


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
