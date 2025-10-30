using UnityEngine;

public class TriggersForCheckLocation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DerTaskCheckLocation.EnterToTriggerZoneLocation();
            Destroy(gameObject);
        }
    }
}
