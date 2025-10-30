using UnityEngine;

public class Provod : GameeObjects
{
    public float Voltage = 0;

    public override void TestActiveDerTask()
    {
        base.TestActiveDerTask();
        GetComponent<DerCable>().Uping();

    }

}
