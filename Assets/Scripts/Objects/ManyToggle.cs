using UnityEngine;
using UnityEngine.Events;

public class ManyToggle : GameeObjects
{
    public UnityEvent eventToggleOn;
    public UnityEvent eventToggleOff;
    public bool isOn;

    public override void TestActiveDerTask()
    {
        base.TestActiveDerTask();
        isOn = !isOn;
        HintAction = (isOn) ? "выключить" : "включить";

        if (isOn)
        {
            eventToggleOn?.Invoke();
        }
        else
        {
            eventToggleOff?.Invoke();
        }

        GetComponent<DerManyToggle>().AddingClick();

    }

}
