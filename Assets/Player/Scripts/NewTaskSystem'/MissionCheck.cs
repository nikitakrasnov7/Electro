using UnityEngine;

public class MissionCheck : TaskAbstract
{

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && IsActive)
            {
                GameManagerGta.Instance.MissionComplete(this);
            }
        }
    }

    public override void OnAction()
    {

    }
}
