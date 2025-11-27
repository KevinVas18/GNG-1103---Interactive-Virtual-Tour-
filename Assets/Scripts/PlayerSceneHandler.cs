using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneHandler : MonoBehaviour
{
    [SerializeField] MonoBehaviour movementScript;   // e.g. your FPS controller
    [SerializeField] MonoBehaviour clickRaycaster;   // your ClickRaycaster

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool inMenu = scene.name == "UI Welcome Screen";

        if (movementScript != null)
            movementScript.enabled = !inMenu;

        if (clickRaycaster != null)
            clickRaycaster.enabled = !inMenu;

        if (inMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
