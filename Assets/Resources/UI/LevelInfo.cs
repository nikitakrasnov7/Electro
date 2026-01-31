using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private TextMeshProUGUI _nameLevel;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _tools;
    [SerializeField] private TextMeshProUGUI _difficulty;

    
    public void UpdateInfo(ButtonLevel infoButton)
    {
        _sprite.sprite = infoButton._sprite;
        _nameLevel.text = infoButton._levelName;
        _description.text = infoButton._description;
        _difficulty.text = infoButton._difficultyLevel;

        string t = "";
        foreach (string tool in infoButton._necessaryTools)
        {
            t += tool + ", ";
        }
        _tools.text = t;

    }
}
