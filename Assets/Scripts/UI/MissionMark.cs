using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MissionMark : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string GameSceneName = "SampleScene";
    [SerializeField] private string UISceneName = "UI";
    [SerializeField] private string MapSceneName = "MapMenu";
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(GameSceneName);
        SceneManager.UnloadSceneAsync(MapSceneName);

        SceneManager.LoadSceneAsync(UISceneName, LoadSceneMode.Additive);
    }
}
