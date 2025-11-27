using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSettingsScene : MonoBehaviour
{
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings UI");
    }
}
