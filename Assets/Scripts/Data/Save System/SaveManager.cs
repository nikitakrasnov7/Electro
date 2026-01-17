using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    [SerializeField] private string saveFileName = "savegame.json";
    [SerializeField] private bool useEncryption = false;
    private SaveData saveData;
    private string savePath;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        savePath = Path.Combine(Application.persistentDataPath, saveFileName);
        Debug.Log("path : " + savePath);
    }
    public void CreateNewSave(Transform player)
    {
        saveData = new SaveData
        {
            playerData = new SaveData.PlayerData(player),
            statisticsData = new SaveData.StatisticsData
            {
                time = 0,
                countClick = 0,
                lastSaveTime = System.DateTime.Now,
            },
            saveData = System.DateTime.Now
        };
        SaveToFile();
    }

    public void SaveGame(Transform player, float time, int countClick)
    {
        if (saveData == null)
        {
            CreateNewSave(player);
            return;
        }

        saveData.playerData = new SaveData.PlayerData(player);
        saveData.statisticsData = new SaveData.StatisticsData
        {
            time = time,
            countClick = countClick,
            lastSaveTime = System.DateTime.Now

        };

        saveData.saveData = System.DateTime.Now;
        SaveToFile();
    }

    public bool LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("нет файла сохранения");
            return false;
        }
        try
        {
            string json = File.ReadAllText(savePath);
            saveData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("загружено сохранение успешно");
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.Log($"ошибка сохранения = {ex}");
            return false;
        }
    }

    public SaveData GetSaveData()
    {
        
        return saveData;
    }
    private void SaveToFile()
    {
        try
        {
            string json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(savePath, json);
            Debug.Log("игра сохранена успешно");
        }
        catch (System.Exception ex)
        {
            Debug.Log("ошибка сохранения " + ex);
        }
    }
    public bool HasSaveFile()
    {
        return File.Exists(savePath);
    }
    public void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            saveData = null;
            Debug.Log("файл удален");
        }
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
