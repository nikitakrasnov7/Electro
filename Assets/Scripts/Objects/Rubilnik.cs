using UnityEngine;

public class Rubilnik : MonoBehaviour
{
    public Animator animator;
    public Lamp[] lamp;

    [System.Obsolete]
    private void OnEnable()
    {
        lamp = FindObjectsOfType<Lamp>();
        Electrisyty.isWork = true;
    }
    public void OnAnimator()
    {
        animator.SetBool("on", true);
        foreach (var lamp in lamp)
        {
            lamp.NoLighting();
        }
        Electrisyty.isWork = false;
    }
    public void OffAnimator()
    {
        animator.SetBool("on", false);
        Electrisyty.isWork = true;
        foreach (var l in lamp)
        {
            l.Lighting();
        }
    }
}
