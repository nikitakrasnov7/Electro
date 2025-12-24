using System;
using UnityEngine;
[System.Serializable]
public class SaveData
{
    [System.Serializable]
    public class PlayerData
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;
        public PlayerData() { }
        public PlayerData(Transform player)
        {
            Position = player.position;
            Rotation = player.eulerAngles;
            Scale = player.localScale;
        }
    }

    [System.Serializable]
    public class StatisticsData
    {
        public float time;
        public int countClick;
        public DateTime lastSaveTime;
    }

    public PlayerData playerData;
    public StatisticsData statisticsData;
    public int version = 1;
    public DateTime saveData;
}
