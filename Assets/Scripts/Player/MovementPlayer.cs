using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class MovementPlayer : MonoBehaviour
{
    Rigidbody rb;
    Transform camera;
    public float Speed = 10f;

    private void Awake()
    {
        camera = Camera.main.transform;
        rb = GetComponent<Rigidbody> ();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float mouseHorizontal = Input.GetAxis("Mouse X");
        float mouseVertical = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseHorizontal);
        Vector3 clamp = Vector3.ClampMagnitude(Vector3.left * mouseVertical, 90);
        camera.Rotate(clamp);

        Vector3 transformLocal = new Vector3(horizontal, 0, vertical);
        Vector3 transformGlobal = transform.TransformDirection(transformLocal);

        rb.linearVelocity = transformGlobal * Speed;


    }


}
