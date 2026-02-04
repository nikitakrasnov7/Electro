using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CorrectClick : TaskAbstract, ITaskDescription
{
    [SerializeField] GameObject InfoButton;
    [SerializeField] List<int> correctClicks = new List<int>();
    private List<int> UserClicks = new List<int>();

    
    

    public override void OnAction()
    {
        InfoButton.SetActive(true);
        UIController.Instance.UpdateTaskHint(HintDescription);
        UIController.Instance.OpenHintButton(true);
    }

    public void GetClick(int clickInfo)
    {
        UserClicks.Add(clickInfo);
    }


    private void Checking()
    {
        if (correctClicks.Count == UserClicks.Count)
        {
            int correct = 0;
            for (int i = 0; i < correctClicks.Count; i++)
            {
                if (correctClicks[i] == UserClicks[i])
                {
                    correct++;
                }
            }
            if (correct == correctClicks.Count)
            {
                print("все правильно");

            }
            else
            {
                print("неправильно");
            }
        }
    }
    private void Update()
    {
        Checking();
    }
}
