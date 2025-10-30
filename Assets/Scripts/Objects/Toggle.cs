using UnityEngine;

public class Toggle : GameeObjects
{


    public override void TestActiveDerTask()
    {
        base.TestActiveDerTask();
        GetComponent<DerToggle>().OffingToggle();
        
    }

}
