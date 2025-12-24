
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;

using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    private IDbConnection db;
    public UnityEvent events;

    void Start()
    {
        string path = Application.dataPath + "/game.db";

        db = new SqliteConnection("URI=file:" + path);
        db.Open();

        string sql = "CREATE TABLE IF NOT EXISTS session (id INTEGER PRIMARY KEY, player_name TEXT, level INTEGER DEFAULT 1, missions INTEGER DEFAULT 0)";

        using (IDbCommand cmd = db.CreateCommand())
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        Debug.Log("База готова");
        events.Invoke();
    }

    public void AddOrUpdatePlayer(string playerName)
    {
        using (IDbCommand cmd = db.CreateCommand())
        {
            cmd.CommandText = "DELETE FROM session";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO session (player_name, level, missions) VALUES ('" + playerName + "', 1, 0)";
            cmd.ExecuteNonQuery();

            Debug.Log("Создана новая сессия: " + playerName);
        }
    }

    public bool HasSavedSession()
    {
        using (IDbCommand cmd = db.CreateCommand())
        {
            cmd.CommandText = "SELECT COUNT(*) FROM session";
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            return count > 0;
        }
    }

    public string GetSavedPlayerName()
    {
        using (IDbCommand cmd = db.CreateCommand())
        {
            cmd.CommandText = "SELECT player_name FROM session LIMIT 1";

            using (IDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
        }

        return "";
    }

    public void AddMission()
    {
        using (IDbCommand cmd = db.CreateCommand())
        {
            cmd.CommandText = "UPDATE session SET missions = missions + 1";
            cmd.ExecuteNonQuery();
            Debug.Log("Добавлено задание");
        }
    }

    public void SetLevel(int newLevel)
    {
        using (IDbCommand cmd = db.CreateCommand())
        {
            cmd.CommandText = "UPDATE session SET level = " + newLevel;
            cmd.ExecuteNonQuery();
        }
    }

    public int GetLevel()
    {
        using (IDbCommand cmd = db.CreateCommand())
        {
            cmd.CommandText = "SELECT level FROM session LIMIT 1";
            object result = cmd.ExecuteScalar();
            if (result != null)
                return int.Parse(result.ToString());
        }
        return 1;
    }

    public int GetMissions()
    {
        using (IDbCommand cmd = db.CreateCommand())
        {
            cmd.CommandText = "SELECT missions FROM session LIMIT 1";
            object result = cmd.ExecuteScalar();
            if (result != null)
                return int.Parse(result.ToString());
        }
        return 0;
    }

    public void DeleteSession()
    {
        using (IDbCommand cmd = db.CreateCommand())
        {
            cmd.CommandText = "DELETE FROM session";
            cmd.ExecuteNonQuery();
            Debug.Log("Сессия удалена");
        }
    }

    void OnDestroy()
    {
        if (db != null)
        {
            db.Close();
        }
    }
}

