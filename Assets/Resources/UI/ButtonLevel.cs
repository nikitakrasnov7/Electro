using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour, IPointerClickHandler
{
    public Sprite _sprite;
    [SerializeField] public int _levelIndex;
    [SerializeField] public string _levelName;
    [SerializeField] public string _description;
    [SerializeField] public string _difficultyLevel;
    [SerializeField] public string[] _necessaryTools;

    private LevelInfo LevelInfo;

    private void Awake()
    {
        _sprite = GetComponent<Image>().sprite;
        LevelInfo = FindAnyObjectByType<LevelInfo>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        LevelInfo.UpdateInfo(this);
    }




}
