using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;   // <-- for TextMeshPro

public class SpawnRotatable : MonoBehaviour
{
    [Header("3D Stuff")]
    public GameObject objectPrefab;
    public float distanceFromCamera = 2.5f;
    private GameObject currentObj;

    [Header("UI Stuff")]
    public TMP_Text infoText;      // drag your Text (TMP) here
    [TextArea] public string shownMessage = "This is the machine. It filters water and ...";
    public string hiddenMessage = "";   // what to show when closed

    public void ToggleObject()
    {
        // no object yet -> spawn + show text
        if (currentObj == null)
        {
            Spawn();
            SetText(shownMessage);
        }
        else   // object exists -> hide + clear text
        {
            Destroy(currentObj);
            currentObj = null;
            SetText(hiddenMessage);
        }
    }

    private void Spawn()
    {
        Camera cam = Camera.main;
        Vector3 pos = cam.transform.position + cam.transform.forward * distanceFromCamera;

        currentObj = Instantiate(objectPrefab, pos, Quaternion.identity);

        if (currentObj.GetComponent<Collider>() == null)
            currentObj.AddComponent<BoxCollider>();

        if (currentObj.GetComponent<DragRotate>() == null)
            currentObj.AddComponent<DragRotate>();
    }

    private void SetText(string msg)
    {
        if (infoText != null)
            infoText.text = msg;
    }
}
