using UnityEngine;

public abstract class TaskAbstract : MonoBehaviour, ITaskDescription
{

    private bool isActive = false;
    public bool IsActive
    {
        get; set;
    }

    private bool isComplete = false;
    public bool IsComplete { get; set; }

    [field: SerializeField]
    public string Description { get; set; }
    public string HintDescription;

    protected void Start()
    {
        IsActive = true;
    }
    protected void End()
    {
        if (IsActive && !IsComplete)
        {
            IsActive = false;
            IsComplete = true;
        }
    }

    public void StartMission() => Start();
    public void EndMission() => End();


    public abstract void OnAction();

}
