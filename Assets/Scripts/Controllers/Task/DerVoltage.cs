using Unity.Android.Gradle;
using UnityEngine;

public class DerVoltage : AbstractTask
{
    [Header("Lines Settings")]
    public TestLine PlayerLine;
    public TestLine GameLine;

    public Joystick Amplitude;
    public Joystick Fequence;

    public float minValue;
    public float maxValueAmplitude;
    public float maxValueFrequence;

    private float gameAmplitude;
    private float gameFrequence;

    public Gradient finish;
    public Gradient nofinish;


    //public Joystick test1;
    //public Joystick test2;

    public GameObject CanvasElectroBox;
    public override void FinishMission()
    {
        isActive = false;
        isComplete = true;
    }

    public override void StartMission()
    {
        isActive = true;
        isComplete = false;

        Amplitude.events.AddListener(UpdateAmplitude);
        Fequence.events.AddListener(UpdateFrequency);

        GenerateGameLine();
    }

    public override bool TrackingMission()
    {

        CheckLine();
        if (Input.GetKeyDown(KeyCode.F) && CheckLine())
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void GenerateGameLine()
    {
        gameAmplitude = Random.Range(minValue, maxValueAmplitude);
        gameFrequence = Random.Range(minValue, maxValueFrequence);

        GameLine.amplitude = gameAmplitude;
        GameLine.frequency = gameFrequence;

        print("–¿¡Œ“¿…");

    }
    public bool CheckLine()
    {
        if (PlayerLine.amplitude <= gameAmplitude + 0.05f && PlayerLine.amplitude >= gameAmplitude - 0.05f && PlayerLine.frequency <= gameFrequence + 0.05f && PlayerLine.frequency >= gameFrequence - 0.05f)
        {
            PlayerLine.lineRenderer.colorGradient = finish;
            return true;
        }
        else
        {
            PlayerLine.lineRenderer.colorGradient = nofinish;
            return false;
        }
    }
    public void UpdateAmplitude()
    {
        float a = PlayerLine.amplitude + Amplitude.rotateValue * 0.01f;
        float aC = Mathf.Clamp(a, minValue, maxValueAmplitude);
        PlayerLine.amplitude = aC;
        CheckLine();
    }
    public void UpdateFrequency()
    {
        float f = PlayerLine.frequency + Fequence.rotateValue * 0.01f;
        float fC = Mathf.Clamp(f, minValue, maxValueFrequence);
        PlayerLine.frequency = fC;

        CheckLine();
    }
}


