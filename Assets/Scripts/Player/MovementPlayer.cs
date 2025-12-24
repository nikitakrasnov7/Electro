using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementPlayer : MonoBehaviour
{
    Rigidbody rb;
    Transform camera;
    public float Speed = 10f;
    public static bool isBoots;
    public static Transform HandPosition;

    public void Init()
    {
        camera = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        HandPosition = GetComponentInChildren<TestHand>().gameObject.transform;
    }

    public void PlayerControlling()
    {
        Rotate();
        PlayerMove();
        if (isBoots)
        {

            Uping();
        }
    }
    private void Rotate()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X");
        float mouseVertical = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseHorizontal);
        Vector3 clamp = Vector3.ClampMagnitude(Vector3.left * mouseVertical, 90);
        camera.Rotate(clamp);

    }
    void Uping()
    {
        float up;
        if (Input.GetKey(KeyCode.Q))
        {
            up = -1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            up = 1;
        }
        else
        {
            up = 0;
        }

        rb.MovePosition(rb.position + transform.up * up * 3 * Time.deltaTime);
    }
    private void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 transformLocal = new Vector3();
        transformLocal.x = horizontal;
        transformLocal.z = vertical;
        Vector3 transformGlobal = transform.TransformDirection(transformLocal);

        rb.MovePosition(rb.position + transformGlobal * Speed * Time.deltaTime);
    }


}
