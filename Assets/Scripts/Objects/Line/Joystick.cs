using UnityEngine;
using UnityEngine.Events;

public class Joystick : MonoBehaviour
{
    public float rotateValue;
    public float Speed = 5f;
    public Transform rotateObject;

    public UnityEvent events;

    public void LeftRotate()
    {
        rotateValue = 1;

    }
    public void RigthRotate()
    {
        rotateValue = -1;

    }
    public void StopRotate()
    {
        rotateValue = 0;

    }
  

    private void Update()
    {
        rotateObject.Rotate(0, 0, rotateValue * Speed * Time.deltaTime);
        events.Invoke();
    }
}
