using UnityEngine;

public class TestLine : MonoBehaviour
{
     public LineRenderer lineRenderer;
    [Min(0)]
    public int Points = 10;

    public float amplitude = 1;
    public float frequency = 1;
    public Vector2 xLimits = new Vector2(0, 1);
    public float speed;

    private void Start()
    {
        lineRenderer.transform.rotation = Quaternion.Euler(0,0,0);
    }
   
    void Update()
    {
        Draw();
        
    }

    private void Draw()
    {
        float xStart = 0;
        float Tau = 2 * Mathf.PI;
        float xFinish = Tau;

        lineRenderer.positionCount = Points;
        for (int currentPoint = 0; currentPoint < Points; currentPoint++)
        {
            float progress = (float)currentPoint / (Points - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            
            float y = amplitude * Mathf.Sin((Tau * frequency * x) + Time.timeSinceLevelLoad * speed);
            lineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
        }

    }
}
