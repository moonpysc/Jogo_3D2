using UnityEngine;

public class ControllerMove : MonoBehaviour
{
    [Header("Movement")]

    public float velocity = 5f;
    public float jumpForce = 6f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get movement input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0f, v);

        // Prevent diagonal movement from being faster
        movement = Vector3.ClampMagnitude(movement, 1f);

        // Move horizontally
        controller.Move(movement * velocity * Time.deltaTime);

        // Ground check
        if (controller.isGrounded)
        {
            if (verticalVelocity.y < 0f)
                verticalVelocity.y = -2f;

            // Jump
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity.y = jumpForce;
            }
        }

        // Gravity
        verticalVelocity.y += gravity * Time.deltaTime;

        // Move vertically
        controller.Move(verticalVelocity * Time.deltaTime);
    }
}