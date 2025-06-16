using UnityEngine;
using UnityEngine.UI;

public class clickGame : MonoBehaviour
{
    [SerializeField] Button targetButton;
    [SerializeField] RectTransform canvasRect;
    [SerializeField] GameObject miniGame;
    
    [Header("Horizontal")]
    [SerializeField] float minX, maxX; //245

    [Header("Vertical")]
    [SerializeField] float minY, maxY; //210

    void OnEnable()
    {
        if (targetButton == null || canvasRect == null) return;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        RectTransform buttonRect = targetButton.GetComponent<RectTransform>();
        buttonRect.anchoredPosition = new Vector2(randomX, randomY);
    }

    public void miniGameEnd()
    {
        if (miniGame != null)
        {
            miniGame.SetActive(false);
        }
    }
}