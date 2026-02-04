using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckMouseCursor : MonoBehaviour, IInfoMission
{
    [field:SerializeField]
    public string Hint { get ; set ; }

    [SerializeField] private TextMeshPro hintText;

    private void Start()
    {
        hintText = GetComponentInChildren<TextMeshPro>();
        hintText.text = "";
    }
    private void OnMouseEnter()
    {
        hintText.text = Hint;
    }
    private void OnMouseExit()
    {
        hintText.text = "";
    }
}

