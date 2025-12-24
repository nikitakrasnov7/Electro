using UnityEngine;

public class DoorOpen : GameeObjects
{
    Rigidbody body;
    private void OnEnable()
    {
        body = GetComponent<Rigidbody>();
    }
    public override void TestActiveDerTask()
    {
        base.TestActiveDerTask();
        body.AddForce(Vector3.back*3, ForceMode.Impulse);
        GetComponent<DerOpenDoor>().isOpen = true;
    }
}
