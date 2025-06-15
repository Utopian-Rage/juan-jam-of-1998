using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class clickGame : MonoBehaviour
{
    [SerializeField] Button targetButton;
    [SerializeField] RectTransform canvasRect;
    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;
    [SerializeField] GameObject obj;



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
        if (obj != null)
        {
            obj.SetActive(false);
        }
    }
}