using Mono.Cecil;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TestMoveCamera : MonoBehaviour
{
    [SerializeField] Transform PLayer;
    [SerializeField] Transform point;
    Quaternion startRotate;
    public Transform Point
    {
        set
        {
            point = value;
        }
    }
    [SerializeField] float speedMove = 0.1f;
    private Transform target;
    private void Start()
    {
        target = PLayer;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && point != null)
        {
            target = (target == PLayer) ? point : PLayer;
            if(target == point)
            {
                startRotate = transform.rotation;
            }
            if (target == PLayer)
            {

                transform.rotation = startRotate;
            }
            transform.SetParent(target);

        }
        if (target != PLayer)
        {
            transform.LookAt(target.transform.parent);
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, speedMove);


    }

}
