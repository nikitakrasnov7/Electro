using System.Collections;
using UnityEngine;

public class MapMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject newMark;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform leftDownPoint;
    [SerializeField] private Transform rightUpPoint;

    int maxCountMark;
    private void Start()
    {
        StartCoroutine(Factory());
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
        while (maxCountMark < 30)
        {
            CreateMark();
            maxCountMark++;
            yield return new WaitForSeconds(Random.Range(3,10));
        }
    }
}
