using UnityEngine;

public class Toggle : GameeObjects
{


    public override void TestActiveDerTask()
    {
        base.TestActiveDerTask();
        GetComponent<DerToggle>().OffingToggle();
        Debug.Log(GetComponent<DerToggle>() == null);
    }

}
