using UnityEngine;
using UnityEngine.SceneManagement;

public class DataGame : MonoBehaviour
{
    void Start()
    {
        int playerId = PlayerPrefs.GetInt("PlayerId", -1);
        int sessionId = PlayerPrefs.GetInt("SessionId", -1);

        if (playerId != -1)
        {
            Debug.Log("Играем за: " + playerId);
            Debug.Log("Сессия: " + sessionId);
        }
        else
        {
            Debug.Log("Нет игрока");
        }

        Debug.Log("Игра началась");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveGame();
            SceneManager.LoadScene("MainMenu");
        }
    }

    void SaveGame()
    {
        Debug.Log("Игра сохранена");
    }
}
