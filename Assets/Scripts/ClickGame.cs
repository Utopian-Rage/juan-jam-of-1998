using UnityEngine;
using UnityEngine.UI;

public class RandomButtonMover : MonoBehaviour
{
    public Button targetButton;
    public RectTransform canvasRect;
    public float minX = 0f, maxX = 800f;
    public float minY = 0f, maxY = 600f;

    void OnEnable()
    {
        if (targetButton == null || canvasRect == null) return;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Set the button's anchored position
        RectTransform buttonRect = targetButton.GetComponent<RectTransform>();
        buttonRect.anchoredPosition = new Vector2(randomX, randomY);
    }
}