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
        CountTriggersZone= FindObjectsOfType<TriggersForCheckLocation>().Length;
        Debug.Log(CountTriggersZone);
        isActive = true;
    }

    public override bool TrackingMission()
    {
        Debug.Log("задание идет :" +  CountTriggersZone);
        if (CountTriggersZone == 0)
        {
            Debug.Log("Задание выполнено");
            return true;    
        }
        return false;
    }
    public static void EnterToTriggerZoneLocation()
    {
        CountTriggersZone--;
    }
}
