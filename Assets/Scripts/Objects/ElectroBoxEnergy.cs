using UnityEngine;

public class ElectroBoxEnergy : MonoBehaviour
{
    public Material green;
    public Material red;

    public void Offing()
    {
        GetComponent<MeshRenderer>().material = red;
    }
    public void Oning()
    {
        GetComponent<MeshRenderer>().material = green;

    }
}
