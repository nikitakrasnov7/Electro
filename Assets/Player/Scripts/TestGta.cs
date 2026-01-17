using UnityEngine;

public class TestGta : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(rb.linearVelocity.magnitude);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
        }
    }
}
