using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartScene : MonoBehaviour
{
    public void LoadStart()
    {
        SceneManager.LoadScene("UI Welcome Screen");
    }
}
