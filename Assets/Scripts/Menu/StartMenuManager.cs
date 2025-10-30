using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
   [SerializeField] private string SceneMap = "MapMenu";

    public void StartingNewGame()
    {
        SceneManager.LoadScene(SceneMap);
    }
    public void ResumeGame()
    {
        //TODO
    }
    public void OpenSettings()
    {
        //TODO
    }
}
