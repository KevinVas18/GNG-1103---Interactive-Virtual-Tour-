using UnityEngine;

public class ClickRaycaster : MonoBehaviour
{
    public float maxDistance = 5f;
    public GameObject ui;

    void Start()
    {
        if (ui != null)
            ui.SetActive(false);
    }

    void Update()
    {
        // Start each frame assuming we're not on a button
        LabButton3D button = null;

        // Ray from center of screen (crosshair style)
        Ray ray = Camera.main.ScreenPointToRay(
            new Vector3(Screen.width / 2f, Screen.height / 2f, 0f)
        );

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            // See if what we hit is a LabButton3D
            if (hit.collider.TryGetComponent<LabButton3D>(out button))
            {
                // We are looking at a button → show UI
                if (ui != null)
                    ui.SetActive(true);

                // Click to activate
                if (Input.GetMouseButtonDown(0))
                {
                    button.OnPressed();
                }
            }
            else
            {
                // Hit something, but not a button → hide UI
                if (ui != null)
                    ui.SetActive(false);
            }
        }
        else
        {
            // Hit nothing → hide UI
            if (ui != null)
                ui.SetActive(false);
        }
    }
}
