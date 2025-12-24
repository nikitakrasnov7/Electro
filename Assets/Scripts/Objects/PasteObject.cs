using UnityEngine;
using UnityEngine.Events;

public class PasteObject : MonoBehaviour
{
    public Transform Parent;
    public Collider Collider;

    public UnityEvent events;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == Collider)
        {
            transform.position = Parent.GetChild(0).position;
            transform.rotation = Parent.GetChild(0).rotation;
            transform.SetParent(Parent);
            if (gameObject.GetComponent<AbstractTask>())
            {
                FindAnyObjectByType<GameManager>().CompletingMission();

                events?.Invoke();
            }


        }
    }
}
