using UnityEngine;
using UnityEngine.UI;

public class canvastoworldspace : MonoBehaviour
{
    public GameObject uiPrefab;  // This public variable should be set to the prefab of the UI element you want to place in world space.

    private Canvas worldCanvas;  // This variable will hold a reference to the created world space Canvas component.

    private void Start()
    {
        // Create a new Canvas GameObject and set its render mode to World Space.
        GameObject canvasObject = new GameObject("WorldSpaceCanvas");
        worldCanvas = canvasObject.AddComponent<Canvas>();
        worldCanvas.renderMode = RenderMode.WorldSpace;

        // Create an Image GameObject as a child of the Canvas.
        GameObject imageObject = Instantiate(uiPrefab, worldCanvas.transform);
        Image image = imageObject.GetComponent<Image>();

        // Position the Canvas in world space.
        canvasObject.transform.position = new Vector3(0f, 2f, 0f);

        // Set the size and position of the Image on the Canvas.
        image.rectTransform.sizeDelta = new Vector2(200f, 100f);
        image.rectTransform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
    }
}
