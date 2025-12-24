
using System;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    GameObject raySelectObject;

    List<GameObject> listMissions;
    int indexActiveMission;

    MovementPlayer playerController;

    [SerializeField] private List<AbstractTask> _tasksLevel;
    DerTaskCheckLocation testMissionCheckingLocation;

    int indexTask = 0;
    private AbstractTask testActiveTask;

    static public Vector3 playerPosition;

    public TestTaskSO ListObjectsForTask;
    float time;
    int countClick;

    [SerializeField] private PlayerSaveController saveController;
    private void Start()
    {

        RayController.mainCamera = Camera.main;
        RayController.S_mask = mask;


        playerController = FindAnyObjectByType<MovementPlayer>();
        playerController.Init();

        testMissionCheckingLocation = FindAnyObjectByType<DerTaskCheckLocation>();

        listMissions = UIController.Instance.UpdateListTasks(ListObjectsForTask.ListTask);

        UpdateTask();
    }
    void Update()
    {

        raySelectObject = RayController.RaycastHiting();
        RayController.DrawingRay();
        CheckingObjectHint();
        UsingRayObject();

        playerController.PlayerControlling();

        playerPosition = playerController.transform.position;
        if (testActiveTask != null && ListObjectsForTask != null)
        {

            TrackingMission();
        }


        LevelResoult();

        TestSave();
        Pause();

    }
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIController.Instance.Pause();
        }
    }
    private void TestSave()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            saveController.SaveGame(time, countClick);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            saveController.LoadPlayerData();
        }
    }
    public void LevelResoult()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            countClick++;
        }
    }
    private string TimeConvert()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(this.time);
        return $"{(int)timeSpan.TotalHours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}:{timeSpan.Milliseconds:D3}"; ;
    }
    private void TrackingMission()
    {
        if (!testActiveTask.isComplete)
        {

            if (!testActiveTask.TrackingMission())
            {
            }
            else
            {
                CompletingMission();

            }

        }
    }
    public void CompletingMission()
    {
        testActiveTask.FinishMission();
        MissionComplete();
        indexTask++;
        print(indexTask + " " + _tasksLevel.Count);
        if (indexTask >= _tasksLevel.Count)
        {
            Debug.Log("Конец уровня");
            UIController.Instance.FinishGame(TimeConvert(), countClick);

        }
        else
        {
            UpdateTask();

        }
    }

    private void UpdateTask()
    {
        if (_tasksLevel[indexTask] != null)
        {

            testActiveTask = _tasksLevel[indexTask];
            testActiveTask.StartMission();
        }

    }
    private void SearchLevelTasks()
    {
        // TODO должны получать из бд
        foreach (var o in listMissions)
        {
            _tasksLevel.Add(o.GetComponent<AbstractTask>());
        }
    }
    private void MissionComplete()
    {
        listMissions[indexActiveMission].GetComponent<TextMeshProUGUI>().text += " +";
        indexActiveMission++;
    }
    private void CheckingObjectHint()
    {
        if (raySelectObject != null)
        {
            if (raySelectObject.GetComponent<GameeObjects>() != null)
            {
                if (raySelectObject.GetComponent<AbstractTask>() != null && raySelectObject.GetComponent<AbstractTask>().isActive)
                {

                }
                UIController.Instance.UpdateHint(raySelectObject.GetComponent<GameeObjects>().HintAction);


            }
        }
        else
        {
            UIController.Instance.UpdateHint("");
        }

    }

    private void UsingRayObject()
    {
        if (raySelectObject != null && raySelectObject.GetComponent<GameeObjects>() != null)
        {
            if (raySelectObject.GetComponent<AbstractTask>() != null && raySelectObject.GetComponent<AbstractTask>().isActive)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {

                    raySelectObject.GetComponent<GameeObjects>().TestActiveDerTask();
                }
            }
        }
    }

}
