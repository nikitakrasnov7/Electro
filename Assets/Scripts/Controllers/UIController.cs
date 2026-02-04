using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_Hint;
    [SerializeField] private GameObject prefabTaskText;
    [SerializeField] private GameObject PanelTask;

    [SerializeField] private GameObject FinishPanel;

    [SerializeField] private TextMeshProUGUI txt_time;
    [SerializeField] private TextMeshProUGUI txt_click;
    [SerializeField] private TextMeshProUGUI txt_result;

    [SerializeField] private GameObject PausePanel;

    [SerializeField] TextMeshProUGUI nikname;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI missiomCount;

    [SerializeField] private SessionInfoSO info;

    List<TextMeshProUGUI> tasksList = new List<TextMeshProUGUI>();

    [Header("New version")]
    [SerializeField] TextMeshProUGUI textHint;
    [SerializeField] Animator TaskHintPanel;
    [SerializeField] GameObject HintButton;
    private static UIController instance;

    public static UIController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<UIController>();
            }
            return instance;
        }
    }
   public void GetInfo()
    {
        nikname.text = info.Nikname;
        level.text = info.level.ToString();
        missiomCount.text = info.missionCompleteCount.ToString();
    }
    public void Pause()
    {
        PausePanel.SetActive(!PausePanel.activeSelf);
        if (PausePanel.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void UpdateHint(string hint)
    {
        txt_Hint.text = hint;
    }
    public void CloseHint()
    {
        txt_Hint.text = "";
    }

    public void UpdateTaskHint(string text)
    {
        textHint.text = text;
    }
    public void FinishGame(string time, int click)
    {
        FinishPanel.SetActive(true);
        txt_time.text = time;
        txt_click.text = click.ToString();
        txt_result.text = "amazing";
    }
    public List<GameObject> UpdateListTasks(List<string> tasks)
    {
        List<GameObject> listTask = new List<GameObject>();
        for (int i = 0; i < tasks.Count; i++)
        {
            GameObject task = Instantiate(prefabTaskText);
            task.transform.SetParent(PanelTask.transform);
            task.transform.localScale = new Vector3(1, 1, 1);
            string t = $"{i + 1}) {tasks[i]}";
            task.GetComponent<TextMeshProUGUI>().text = t;
            listTask.Add(task);

        }
        return listTask;

    }

    public void AddMission(int i,string task)
    {
        GameObject newTask = Instantiate(prefabTaskText);
        newTask.transform.SetParent(PanelTask.transform);
        newTask.transform.localScale = new Vector3(1, 1, 1);
        string t = $"{i + 1}) {task}";
        newTask .GetComponent<TextMeshProUGUI>().text = t;

        tasksList.Add(newTask.GetComponent<TextMeshProUGUI>());
    }
    public void MissionComplete(int i)
    {
        tasksList[i].GetComponent<TextMeshProUGUI>().text += " +";
    }

    public void Resume()
    {
        SceneInfo.Resume();
    }
    public void ExitToMap()
    {
        SceneInfo.ExitToMap();
    }

    public void OpenTaskHint()
    {
        TaskHintPanel.SetBool("isOpen", true);
    }

    public void CloseTaskHint()
    {
        TaskHintPanel.SetBool("isOpen", false);
    }

    public void OpenHintButton(bool state)
    {
        HintButton.SetActive(state);
    }
}
