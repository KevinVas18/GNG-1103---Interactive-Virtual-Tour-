using UnityEngine;
using UnityEngine.InputSystem; // <- new input system

public class DragRotate : MonoBehaviour
{
    public float rotationSpeed = 10f;
    private bool dragging = false;

    void Update()
    {
        // make sure we actually have a mouse (in editor we do)
        if (Mouse.current == null) return;

        // left click pressed this frame
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // raycast from camera to mouse position
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                dragging = true;
            }
        }

        // left click released
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            dragging = false;
        }

        if (dragging)
        {
            Vector2 delta = Mouse.current.delta.ReadValue();
            float rotX = delta.x * rotationSpeed * Time.deltaTime;
            float rotY = delta.y * rotationSpeed * Time.deltaTime;

            // horizontal
            transform.Rotate(Vector3.up, -rotX, Space.World);
            // vertical
            transform.Rotate(Vector3.right, rotY, Space.World);
        }
    }
}
