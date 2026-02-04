using Unity.VisualScripting;
using UnityEngine;

internal class PointForMission : MonoBehaviour, IInfoMission
{
    public Transform Point;

    [field: SerializeField]
    public string Hint { get; set; }

    private void Start()
    {
        Point = transform.parent.transform.GetChild(0);
    }
}