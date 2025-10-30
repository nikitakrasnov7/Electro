using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_Hint;
    [SerializeField] private GameObject prefabTaskText;
    [SerializeField] private GameObject PanelTask;
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

    public void UpdateHint(string hint)
    {
        txt_Hint.text = hint;
    }
    public List<GameObject> UpdateListTasks(List<string> tasks)
    {
        List<GameObject> listTask = new List<GameObject>();
        for (int i=0; i < tasks.Count; i++)
        {
            GameObject task = Instantiate(prefabTaskText);
            task.transform.SetParent(PanelTask.transform);
            task.transform.localScale = new Vector3(1, 1, 1);
            string t = $"{i+1}) {tasks[i]}";
            task.GetComponent<TextMeshProUGUI>().text = t;
            listTask.Add(task);

        }
        return listTask;

    }


}
