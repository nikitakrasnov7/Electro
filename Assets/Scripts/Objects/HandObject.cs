using UnityEngine;

public class HandObject : GameeObjects
{
    public override void TestActiveDerTask()
    {
        base.TestActiveDerTask();
        GetComponent<DerHandObject>().Drag();
    }
}
