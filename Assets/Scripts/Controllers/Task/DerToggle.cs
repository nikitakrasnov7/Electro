using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DerToggle : AbstractTask
{
    [SerializeField] private GameObject canvasHint;

    [SerializeField] private Image imageToggleState;
    [SerializeField] private TextMeshProUGUI textToggleState;


    [SerializeField] private float Distance = 10f;

    [SerializeField] private ParticleSystem ps;
    private bool isOn = false;
    public override void FinishMission()
    {
        ps.Stop();

    }

    public override void StartMission()
    {
        
    }

    public override bool TrackingMission()
    {
        if (!isOn)
        {
            float dis = Vector3.Distance(transform.position, GameManager.playerPosition);
            
            if (dis <= Distance)
            {
                canvasHint.SetActive(true);
                AlthaColor(dis);
            }
            else
            {
                canvasHint.SetActive(false);
            }
            return false;
        }
        else
        {
            
            return true;
        }
    }
    private void AlthaColor(float force)
    {
        float brig = Mathf.InverseLerp(Distance, 1, force);
        brig = Mathf.Clamp01(brig);

        textToggleState.color = Color.Lerp(Color.gray,Color.white,brig);
    }
    public void OffingToggle()
    {
        isOn = true;
        canvasHint.SetActive(false);
        Debug.Log("ssssss" + isOn);
    }

}
