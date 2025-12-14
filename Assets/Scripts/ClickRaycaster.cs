using UnityEngine;
using UnityEngine.UI;   
using TMPro;

public class ClickRaycaster : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float maxDistance = 5f;

    [Header("UI")]
    public GameObject ui;     // Panel / popup
    public TMP_Text uiText;    
    public ControlledVideo videoController;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        if (ui != null)
            ui.SetActive(false);
    }

    private void Update()
    {
        if (cam == null) return;

        // --- 1. Default state every frame: hide UI ---
        if (ui != null)
            ui.SetActive(false);

        if (uiText != null)
            uiText.text = "";

        // --- 2. Shoot ray from center of screen ---
        Ray ray = cam.ScreenPointToRay(
            new Vector3(Screen.width / 2f, Screen.height / 2f, 0f)
        );

        if (!Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            return;

        // --- 3. Check for LabButton3D first ---
        if (hit.collider.CompareTag("LabButton"))
        {
            if (hit.collider.TryGetComponent(out LabButton3D labBtn))
            {
                // Looking at a lab button
                if (ui != null)
                    ui.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                    labBtn.OnPressed();

                return; 
            }
        }

        // --- 4. Check for LoadStartOnClick (start/exit button) ---
        if (hit.collider.CompareTag("ExitButton"))
        {
            if (hit.collider.TryGetComponent(out LoadStartOnClick startBtn))
            {
                if (ui != null)
                    ui.SetActive(true);


                if (Input.GetMouseButtonDown(0))
                    startBtn.OnPressed();

                return;
            }
        }

        if (hit.collider.CompareTag("RewardButton"))
        {
            if (hit.collider.TryGetComponent(out ParkourButton parkourBtn))
            {
                // Looking at a button
                if (ui != null)
                    ui.SetActive(true);
                
                if (Input.GetMouseButtonDown(0))
                    parkourBtn.OnPressed();
                
                return; 
            }
        }
        if (!ui.activeSelf)
        {
            videoController.StopVideo();
        }
        // If it hits something else → UI stays hidden because we reset it at top
    }
}
