using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [Header("Movimento")]

    public float velocity = 5f;
    public float jumpForce = 6f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {

    }
}