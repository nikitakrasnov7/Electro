
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

    //=======================
    public TestTaskSO ListObjectsForTask;
    ////=======================
    //[Header("Lines Settings")]
    //public TestLine PlayerLine;
    //public TestLine GameLine;

    //public Joystick Amplitude;
    //public Joystick Fequence;

    //public float minValue;
    //public float maxValueAmplitude;
    //public float maxValueFrequence;

    //private float gameAmplitude;
    //private float gameFrequence;

    //public Gradient finish;
    //public Gradient nofinish;


    private void Start()
    {

        RayController.mainCamera = Camera.main;
        RayController.S_mask = mask;


        playerController = FindAnyObjectByType<MovementPlayer>();
        playerController.Init();

        testMissionCheckingLocation = FindAnyObjectByType<DerTaskCheckLocation>();

        listMissions = UIController.Instance.UpdateListTasks(TestFirstMissionController.TestListTask);

        UpdateTask();
        //GenerateGameLine();
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
        if (raySelectObject != null && raySelectObject.GetComponent<GameeObjects>() != null )
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                
                raySelectObject.GetComponent<GameeObjects>().TestActiveDerTask();
            }
        }
    }
    //public void UpdateAmplitude()
    //{
    //    float a = PlayerLine.amplitude + Amplitude.rotateValue * 0.01f;
    //    float aC = Mathf.Clamp(a, minValue, maxValueAmplitude);
    //    PlayerLine.amplitude = aC;
    //    CheckLine();
    //}
    //public void UpdateFrequency()
    //{
    //    float f =  PlayerLine.frequency + Fequence.rotateValue * 0.01f;
    //    float fC = Mathf.Clamp(f, minValue, maxValueFrequence);
    //    PlayerLine.frequency = fC;

    //    CheckLine(); 
    //}

    //public void GenerateGameLine() 
    //{
    //    gameAmplitude = Random.Range(minValue, maxValueAmplitude);
    //    gameFrequence= Random.Range(minValue, maxValueFrequence);

    //    GameLine.amplitude = gameAmplitude;
    //    GameLine.frequency = gameFrequence;

    //}
    //public void CheckLine()
    //{
    //    if (PlayerLine.amplitude <= gameAmplitude + 0.05f && PlayerLine.amplitude >= gameAmplitude - 0.05f && PlayerLine.frequency <= gameFrequence + 0.05f && PlayerLine.frequency >= gameFrequence - 0.05f)
    //    {
    //        PlayerLine.lineRenderer.colorGradient = finish;
    //    }
    //    else
    //    {
    //        PlayerLine.lineRenderer.colorGradient=nofinish;
    //    }
    //}
}
