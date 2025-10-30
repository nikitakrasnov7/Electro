
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName ="TestDataTask",fileName ="testTask")]
public class TestTaskSO : ScriptableObject
{
    public List<GameObject> objectsForMission = new List<GameObject>(); 
}
