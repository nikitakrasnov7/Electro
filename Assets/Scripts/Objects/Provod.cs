using UnityEngine;

public class Provod : GameeObjects
{
    public float Voltage = 0;
    
    public override void TestActiveDerTask()
    {
        base.TestActiveDerTask();

        if (DerCable.isHand)
        {
            GetComponent<DerCable>().ConnectionCabel();
            
            return;
        }
        else
        {
          
            GetComponent<DerCable>().Uping();

        }

    }

}
