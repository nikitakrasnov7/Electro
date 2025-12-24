using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MissionMark : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string GameSceneName = "SampleScene";
    [SerializeField] private string UISceneName = "UI";
    [SerializeField] private string MapSceneName = "MapMenu";
    [SerializeField] private int minScene;
    [SerializeField] private int maxScene;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneInfo.ActiveSceneIndex = Random.Range(minScene, maxScene);

        SceneManager.LoadScene(SceneInfo.ActiveSceneIndex);
        SceneManager.UnloadSceneAsync(MapSceneName);

        SceneManager.LoadSceneAsync(UISceneName, LoadSceneMode.Additive);
    }
}
public static class SceneInfo
{
    public static int ActiveSceneIndex;
    public static string MapSceneName = "MapMenu";

    public static void Resume()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void ExitToMap()
    {
        SceneManager.LoadScene(MapSceneName);
    }

}