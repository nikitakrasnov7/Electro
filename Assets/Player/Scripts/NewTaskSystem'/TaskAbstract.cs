using UnityEngine;

public abstract class TaskAbstract : MonoBehaviour
{

    private bool isActive = false;
    public bool IsActive
    {
        get; set;
    }

    private bool isComplete = false;
    public bool IsComplete { get; set; }
    protected void Start()
    {
        isActive = true;
    }
    protected void End()
    {
        if (isActive && !isComplete)
        {
            isActive = false;
            isComplete = true;
        }
    }

    public void StartMission() => Start();
    public void EndMission() => End();


    protected abstract void OnAction();

}
