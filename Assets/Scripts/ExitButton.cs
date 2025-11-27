using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartOnClick : MonoBehaviour
{
    [Header("Assign your player movement script here")]
    public MonoBehaviour playerMovement;

    [Header("Assign your raycaster script here")]
    public MonoBehaviour clickRaycaster;
    [Header("UI Text to Display When Looking At This Button")]
    public string hoverMessage = "Return to Menu";

    public void OnPressed()
    {
        // Unlock + show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Disable player movement (if assigned)
        if (playerMovement != null)
            playerMovement.enabled = false;

        // Disable raycaster so it stops reading clicks
        if (clickRaycaster != null)
            clickRaycaster.enabled = false;

        // Load the menu scene
        SceneManager.LoadScene("UI Welcome Screen");
    }
}
