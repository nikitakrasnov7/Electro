using UnityEngine;
using UnityEngine.EventSystems;

public class UserInfo : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Animator animator;
    bool isState;

    public void OnPointerClick(PointerEventData eventData)
    {
        isState = !isState;
        animator.SetBool("panel", isState);
    }
}
