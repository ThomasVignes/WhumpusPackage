using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class TopDownMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input from horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create movement vector based on input and camera orientation
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0.0f;
        movement.Normalize();

        // Apply movement to rigidbody
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
