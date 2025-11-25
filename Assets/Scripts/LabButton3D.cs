using UnityEngine;

public class LabButton3D : MonoBehaviour
{
    [SerializeField] private GameObject uiToShow;

    public void OnPressed()
    {
        if (uiToShow != null)
        {
            bool isActive = uiToShow.activeSelf;
            uiToShow.SetActive(!isActive);
        }
    }
}
