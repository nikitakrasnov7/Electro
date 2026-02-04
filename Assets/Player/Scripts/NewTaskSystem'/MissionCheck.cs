using UnityEngine;

public class MissionCheck : TaskAbstract
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            End();
        }
    }

    protected override void OnAction()
    {
        
    }
}
