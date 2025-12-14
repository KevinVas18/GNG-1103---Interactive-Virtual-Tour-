using UnityEngine;

public class RaycastTeleport : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform teleportPoint;
    public GameObject hoverText; 

    [Header("Raycast Settings")]
    public float maxDistance = 5f;

    private bool isHovering = false;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(
            new Vector3(Screen.width / 2f, Screen.height / 2f, 0f)
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Hover detection
            if (hit.collider.CompareTag("TeleportButton"))
            {
                if (!isHovering)
                {
                    hoverText.SetActive(true);
                    isHovering = true;
                }

                // Click to teleport
                if (Input.GetMouseButtonDown(0))
                {
                    Teleport();
                }
                return;
            }
        }

        // If ray NOT hitting the button → hide text
        if (isHovering)
        {
            hoverText.SetActive(false);
            isHovering = false;
        }
    }

    void Teleport()
    {
        player.position = teleportPoint.position;
        player.rotation = teleportPoint.rotation;
    }
}
