using UnityEngine;
using UnityEngine.EventSystems;

public class ClickButtons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int clickNumber;
    [SerializeField] private CorrectClick click;
    private static CorrectClick clickController;

    private void Start()
    {
        if (click != null)
        {
            clickController = click;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickController != null)
        {
            clickController.GetClick(clickNumber);
        }
    }
}
