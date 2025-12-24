using System.Collections;
using TMPro;
using UnityEngine;

public class MapMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject newMark;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform leftDownPoint;
    [SerializeField] private Transform rightUpPoint;

    [SerializeField] TextMeshProUGUI nikname;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI missiomCount;

    [SerializeField] private SessionInfoSO info;


    int maxCountMark;
    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(Factory());
    }
    private void OnEnable()
    {
        GetInfo();
    }
    public void GetInfo()
    {
        nikname.text = "player " + info.Nikname;
        level.text = "level "+info.level.ToString();
        missiomCount.text = "mission complete " + info.missionCompleteCount.ToString();
    }
    void CreateMark()
    {
        GameObject newM = Instantiate(newMark);
        newM.transform.SetParent(parent);

        Vector2 newPos = new Vector2(
            Random.Range(leftDownPoint.position.x, rightUpPoint.position.x),
            Random.Range(leftDownPoint.position.y, rightUpPoint.position.y));
        newM.transform.position = newPos;
    }
    IEnumerator Factory()
    {
        while (maxCountMark < 300)
        {
            CreateMark();
            maxCountMark++;
            yield return new WaitForSeconds(Random.Range(3,10));
        }
    }
}
