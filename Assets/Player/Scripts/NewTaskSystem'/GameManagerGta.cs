using UnityEngine;

public class GameManagerGta : MonoBehaviour
{
    [SerializeField] TaskAbstract[] tasks;
    int indexActiveTask = 0;
    TaskAbstract activeTask;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        NextLevel();
    }


    public void NextLevel()
    {
        if (indexActiveTask <= tasks.Length)
        {
            activeTask = tasks[indexActiveTask];
            indexActiveTask++;
        }
        else
        {
            // победа
        }
    }

}
