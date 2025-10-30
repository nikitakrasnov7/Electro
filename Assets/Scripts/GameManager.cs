using NUnit.Framework.Internal;
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

   static public Vector3 playerPosition;

    //public List<AbstractTask> TESTLIST = new  List<AbstractTask>();
    private void Awake()
    {

        RayController.mainCamera = Camera.main;
        RayController.S_mask = mask;

        listMissions = UIController.Instance.UpdateListTasks(TestFirstMissionController.TestListTask);

        playerController = FindAnyObjectByType<MovementPlayer>();
        playerController.Init();

        testMissionCheckingLocation = FindAnyObjectByType<DerTaskCheckLocation>();
        testMissionCheckingLocation.StartMission();
    }
    // Update is called once per frame
    void Update()
    {

        raySelectObject = RayController.RaycastHiting();
        RayController.DrawingRay();
        CheckingObjectHint();

        playerController.PlayerMove();
        playerController.Rotate();

        playerPosition = playerController.transform.position;

        if (!testMissionCheckingLocation.isComplete)
        {

            if (!testMissionCheckingLocation.TrackingMission())
            {

            }
            else
            {
                testMissionCheckingLocation.FinishMission();
                MissionComplete();
            }

        }
    }
    private void SearchLevelTasks()
    {
        // TODO должны получать из бд
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
}
