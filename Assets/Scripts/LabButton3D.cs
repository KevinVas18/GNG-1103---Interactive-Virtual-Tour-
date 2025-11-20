using UnityEngine;

public class LabButton3D : MonoBehaviour
{
    public GameObject textObject; // Assign the text object in the inspector

    public void OnPressed()
    {
        Debug.Log("3D button pressed!");

        // Toggle the text on click
        if (textObject != null)
        {
            textObject.SetActive(!textObject.activeSelf);
        }
    }
}
