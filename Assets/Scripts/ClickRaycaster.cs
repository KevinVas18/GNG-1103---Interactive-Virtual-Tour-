using UnityEngine;

public class ClickRaycaster : MonoBehaviour
{
    public float maxDistance = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                LabButton3D button = hit.collider.GetComponent<LabButton3D>();

                if (button != null)
                {
                    button.OnPressed();
                }
            }
        }
    }
}
