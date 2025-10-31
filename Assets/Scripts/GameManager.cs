using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
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

    //=======================
    public TestTaskSO ListObjectsForTask;
    //=======================
    
    private void Start()
    {

        RayController.mainCamera = Camera.main;
        RayController.S_mask = mask;


        playerController = FindAnyObjectByType<MovementPlayer>();
        playerController.Init();

        testMissionCheckingLocation = FindAnyObjectByType<DerTaskCheckLocation>();

        listMissions = UIController.Instance.UpdateListTasks(TestFirstMissionController.TestListTask);

        UpdateTask();
    }
    // Update is called once per frame
    void Update()
    {

        raySelectObject = RayController.RaycastHiting();
        RayController.DrawingRay();
        CheckingObjectHint();
        UsingRayObject();

        playerController.PlayerMove();
        playerController.Rotate();

        playerPosition = playerController.transform.position;

        TrackingMission();
    }

    private void TrackingMission()
    {
        if (!testActiveTask.isComplete)
        {

            if (!testActiveTask.TrackingMission())
            {
                //Debug.Log(testActiveTask.gameObject.name);
            }
            else
            {
                testActiveTask.FinishMission();
                MissionComplete();
                indexTask++;
                UpdateTask();

            }

        }
    }

    private void UpdateTask()
    {
        if (_tasksLevel[indexTask] != null){

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

            if (Input.GetKeyDown(KeyCode.E))
            {
                
                raySelectObject.GetComponent<GameeObjects>().TestActiveDerTask();
            }
        }
    }
}
