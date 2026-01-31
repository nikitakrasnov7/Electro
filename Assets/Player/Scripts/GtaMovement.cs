using UnityEngine;

public class GtaMovement : MonoBehaviour
{
    [SerializeField][Min(0)] float Speed = 10;
    [SerializeField][Min(0)] float JumpForce = 3;
    [SerializeField] Transform AnimBody;

    Vector3 directionMove;
    Animator animator;
    Rigidbody rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        print(rb.linearVelocity.magnitude);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        directionMove.Set(horizontal, rb.angularVelocity.y, vertical);
        directionMove = AnimBody.transform.TransformDirection(directionMove);

        transform.Rotate(Vector3.up * horizontal *25);
        
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
}
