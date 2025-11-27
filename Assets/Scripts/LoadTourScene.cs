using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTourScene : MonoBehaviour
{
    public void LoadTour()
    {
        SceneManager.LoadScene("Tour");
    }
}
