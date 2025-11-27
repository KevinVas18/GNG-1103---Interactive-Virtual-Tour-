using UnityEngine;

public class LabButton3D : MonoBehaviour
{
    [Header("UI Text to show when looking at this lab button")]
    public string hoverMessage = "Press For More Information!";
    public GameObject uiToShow;
    public void OnPressed()
    {
        if (uiToShow != null)
        {
            bool isActive = uiToShow.activeSelf;
            uiToShow.SetActive(!isActive);
        }
    }   
}
