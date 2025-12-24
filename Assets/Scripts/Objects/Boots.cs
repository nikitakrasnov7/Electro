using UnityEngine;

public class Boots : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<MovementPlayer>() != null)
        {
            MovementPlayer.isBoots = true;
            Destroy(gameObject);
        }
    }
}
