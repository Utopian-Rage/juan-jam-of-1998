using UnityEngine;
using UnityEngine.UI;

public class clickGame : MonoBehaviour
{
    [SerializeField] Button targetButton;
    [SerializeField] RectTransform canvasRect;
    [SerializeField] GameObject miniGame;
    [SerializeField] Canvas uiCanvas;
    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;

    void OnEnable()
    {
        if (targetButton == null || canvasRect == null) return;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        RectTransform buttonRect = targetButton.GetComponent<RectTransform>();
        buttonRect.anchoredPosition = new Vector2(randomX, randomY);
    }

    public void ButtonPressed()
    {
        if (targetButton != null)
        {
            miniGame.SetActive(false);
        }
        if (uiCanvas != null)
        {
            uiCanvas.gameObject.SetActive(false);
        }
    }
}