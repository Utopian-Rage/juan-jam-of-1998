using UnityEngine;
using UnityEngine.UI;

public class clickGame : MonoBehaviour
{
    [SerializeField] Button targetButton;
    [SerializeField] RectTransform canvasRect; //used to get the canvas size
    [SerializeField] Canvas uiCanvas;
    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;

    void OnEnable()
    {
        if (targetButton == null || canvasRect == null) return;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Set the button's anchored position
        RectTransform buttonRect = targetButton.GetComponent<RectTransform>();
        buttonRect.anchoredPosition = new Vector2(randomX, randomY);
    }

    public void ButtonPressed()
    {
        if (targetButton != null)
        {
            targetButton.gameObject.SetActive(false);
        }
        if (uiCanvas != null)
        {
            uiCanvas.gameObject.SetActive(false);
        }
    }
}