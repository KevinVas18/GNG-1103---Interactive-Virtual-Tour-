using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    [Header("Mouse Look")]
    public Transform cameraTransform;
    public float mouseSensitivity = 200f;
    public float minLookX = -80f;
    public float maxLookX = 80f;

    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // lock cursor to center and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleLook();
        HandleMovement();
    }

    void HandleLook()
    {
        // mouse input (old Input system)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // rotate left/right (player body)
        transform.Rotate(Vector3.up * mouseX);

        // rotate up/down (camera, but clamped)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minLookX, maxLookX);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleMovement()
    {
        // WASD input
        float x = Input.GetAxis("Horizontal");   // A/D or left/right
        float z = Input.GetAxis("Vertical");     // W/S or up/down

        // move relative to where player is facing
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // jumping + gravity
        // check if on ground
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // small push down to keep grounded
        }

        // jump
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            // v = sqrt(h * -2 * g)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // apply gravity
        velocity.y += gravity * Time.deltaTime;

        // move with gravity
        controller.Move(velocity * Time.deltaTime);
    }
}
