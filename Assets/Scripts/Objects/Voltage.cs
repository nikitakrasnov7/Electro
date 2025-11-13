using UnityEngine;

public class Voltage : GameeObjects
{
    public override void TestActiveDerTask()
    {
        base.TestActiveDerTask();
        GetComponent<DerVoltage>().CanvasElectroBox.SetActive(true);
    }
}
