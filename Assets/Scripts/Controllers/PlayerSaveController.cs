using UnityEngine;

public class PlayerSaveController : MonoBehaviour
{
    public void StartSave()
    {
        if (SaveManager.Instance.HasSaveFile() && SaveManager.Instance.LoadGame())
        {

        }
    }

    public  void LoadPlayerData()
    {
        bool loaded = SaveManager.Instance.LoadGame();
        var data = SaveManager.Instance.GetSaveData();
        
        if (data != null && data.playerData != null)
        {
            transform.position = data.playerData.Position;
            transform.eulerAngles = data.playerData.Rotation;
            transform.localScale = data.playerData.Scale;
        }
    }

    private void LoadStatics()
    {
        var data = SaveManager.Instance.GetSaveData();

    }

    public void SaveGame(float time, int click)
    {
        SaveManager.Instance.SaveGame(transform, time, click);
    }
}