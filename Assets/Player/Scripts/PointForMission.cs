using Unity.VisualScripting;
using UnityEngine;

internal class PointForMission : MonoBehaviour
{
    public Transform Point;

    private void Start()
    {
        Point = transform.parent.transform.GetChild(0);
    }
}