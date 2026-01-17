using UnityEngine;

[CreateAssetMenu(menuName ="session",fileName ="activeSession")]
public class SessionInfoSO : ScriptableObject
{
    public string Nikname;
    public int level;
    public int missionCompleteCount;

    public void LevelUp()
    {
        level = missionCompleteCount / 3;
    }
}
