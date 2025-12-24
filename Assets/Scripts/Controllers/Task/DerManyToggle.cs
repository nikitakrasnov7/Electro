

public class DerManyToggle : AbstractTask
{
    int clickCount;
    public int maxClick;

    
    private void OnEnable()
    {
        isActive = true;
    }
    public override void FinishMission()
    {
        isComplete = true;
    }
    public void AddingClick()
    {
        clickCount++;
    }
    public override void StartMission()
    {
        isComplete = false;
        isActive = true;
        clickCount = 0;
    }

    public override bool TrackingMission()
    {
        if(clickCount >= maxClick)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
