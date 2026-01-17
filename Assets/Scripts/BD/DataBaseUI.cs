using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataBaseUI : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button continueButton;

    private DataManager db;
    public SessionInfoSO info;

    
    public void Init() { 
     db = FindObjectOfType<DataManager>();
        
        if (db.HasSavedSession())
        {
            continueButton.interactable = true;
            string playerName = db.GetSavedPlayerName();
            continueButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continue: " + playerName;
        }
        else
        {
            continueButton.interactable = false;
            continueButton.GetComponentInChildren<TextMeshProUGUI>().text = "not save game";
        }
    }
    public void OnStartNewGame()
    {
        string playerName = nameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            print("Введите имя!");
            return;
        }

        db.AddOrUpdatePlayer(playerName);

        PlayerPrefs.SetString("CurrentPlayer", playerName);
        info.Nikname = playerName;
        info.level = 0;
        info.missionCompleteCount = 0;
        SceneManager.LoadScene("MapMenu");
    }

    public void OnContinueGame()
    {
        if (db.HasSavedSession())
        {
            string playerName = db.GetSavedPlayerName();
            print("продолжена сессия игрока " + playerName);
            SceneManager.LoadScene("MapMenu");
        }
        else
        {
            print("Нет сохраненной игры!");
        }
    }

    public void OnDeleteGame()
    {
        db.DeleteSession();

        continueButton.interactable = false;
        continueButton.GetComponentInChildren<Text>().text = "Нет сохраненной игры";

        print("Сохранение удалено");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

}
