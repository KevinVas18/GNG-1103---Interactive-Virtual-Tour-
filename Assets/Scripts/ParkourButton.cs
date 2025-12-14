using UnityEngine;

public class ParkourButton : MonoBehaviour
{   
    [Header("UI Text to show when looking at this lab button")]
    public string hoverMessage = "Press For More Information!";
    public GameObject uiToShow;

    public ControlledVideo videoController;
    public void OnPressed()
    {
        videoController.PlayVideo();

        if (uiToShow != null)
        {
            bool isActive = uiToShow.activeSelf;
            uiToShow.SetActive(!isActive);
            
        }
    }   
}
