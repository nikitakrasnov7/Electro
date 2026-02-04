using UnityEngine;

public class GameManagerGta : MonoBehaviour
{
    [SerializeField] TaskAbstract[] tasks;
    int indexActiveTask = 0;
    TaskAbstract activeTask;

    private static GameManagerGta instance;
    public static GameManagerGta Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameManagerGta>();
            }
            return instance;
        }
    }

    private void Start()
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            UIController.Instance.AddMission(i, tasks[i].Description);
        }
        NextLevel();
    }


    public void NextLevel()
    {
        if (indexActiveTask <= tasks.Length - 1)
        {
            activeTask = tasks[indexActiveTask];
            indexActiveTask++;
        }
        else
        {
            // победа
        }
    }
    public void MissionComplete(TaskAbstract task)
    {
        if (task == activeTask)
        {

            task.EndMission();
            UIController.Instance.MissionComplete(indexActiveTask - 1);
            NextLevel();
        }
    }

}
