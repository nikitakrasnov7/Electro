using UnityEngine;

public class DeletingObject : GameeObjects
{

    public override void TestActiveDerTask()
    {
        base.TestActiveDerTask();
        GetComponent<DerDeletingObject>().Delete();
    }
}
