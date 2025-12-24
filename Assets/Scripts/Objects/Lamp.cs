using UnityEngine;

public class Lamp : MonoBehaviour
{
    public bool isOn;
    public bool isWork;
    public GameObject Light;
    public void OnLight()
    {
        isOn = true;
        if (!Electrisyty.isWork) return;
        Lighting();
    }
    public void Lighting()
    {
        if (isOn && isWork)
        {
            Light.SetActive(true);
        }
    }
    public void NoLighting()
    {
        Light.SetActive(false);
    }
    public void OffLight()
    {
        isOn = false;
        NoLighting();
    }
    public void Remont()
    {
        isWork = true;
    }
}

public static class Electrisyty
{
    public static bool isWork;
}
