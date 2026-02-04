using System.Runtime.Versioning;
using UnityEngine;

public class GtaMovement : MonoBehaviour
{
    [SerializeField][Min(0)] float Speed = 10;
    [SerializeField][Min(0)] float JumpForce = 3;
    [SerializeField][Min(0)] float RotateSpeed = 20;
    [SerializeField] Transform AnimBody;
    MoveCamera moveCamera;
    Transform target;

    Vector3 directionMove;
    Animator animator;
    Rigidbody rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        moveCamera = FindAnyObjectByType<MoveCamera>();
    }
    private void Update()
    {
        Move();

    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        directionMove.Set(horizontal, rb.angularVelocity.y, vertical);
        directionMove = AnimBody.transform.TransformDirection(directionMove);

        transform.Rotate(Vector3.up * horizontal * RotateSpeed);

        animator.SetFloat("MoveSpeed", vertical);
        animator.SetFloat("HorSpeed", horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed *= 2;
            animator.SetBool("isRun", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed /= 2;
            animator.SetBool("isRun", false);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + directionMove * Speed * Time.fixedDeltaTime);

    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point") && other.gameObject.GetComponent<PointForMission>() != null)
        {
            target = other.gameObject.GetComponent<PointForMission>().Point;
            if (moveCamera != null && target != null)
            {
                UIController.Instance.UpdateHint(other.gameObject.GetComponent<PointForMission>().Hint);
                moveCamera.Point = target;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Point") && other.gameObject.GetComponent<PointForMission>() != null)
        {
            moveCamera.Point = null;
            UIController.Instance.CloseHint();
            target = null;
        } 
    }
   
}
