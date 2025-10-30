using UnityEditor;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public static Camera mainCamera;
   public static LayerMask S_mask;
    private static Ray CreatingRay()
    {
        return new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        
    }
    public static GameObject RaycastHiting()
    {
        if (Physics.Raycast(CreatingRay(), out RaycastHit hit, 5,S_mask)) 
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }

    }
    public static void DrawingRay()
    {
        Debug.DrawRay(mainCamera.transform.position,mainCamera.transform.forward, Color.red);
    }

}
