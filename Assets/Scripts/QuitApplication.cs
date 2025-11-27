using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void QuitGame()
    {
        // If running in a built game → quit
        Application.Quit();

        // If running inside the Unity Editor → stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
