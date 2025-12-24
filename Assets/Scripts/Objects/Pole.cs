using UnityEngine;

public class Pole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<MovementPlayer>() != null)
        {
            Physics.gravity = new Vector3(0,0,0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MovementPlayer>() != null)
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
    }
}
