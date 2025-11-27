using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInstructionsScene : MonoBehaviour
{
    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
