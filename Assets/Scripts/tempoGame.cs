using UnityEngine;
using UnityEngine.UI;
public class tempoGame : MonoBehaviour
{
    [SerializeField] RectTransform canvasRect;
    [SerializeField] GameObject miniGame;
    [SerializeField] Scrollbar gameBar;
    [SerializeField] Scrollbar goalBar;
    [SerializeField] Sprite normalHandleSprite;
    [SerializeField] Sprite goalHandleSprite;
    [SerializeField] float stayTimer = 0f;
    private float valueGoal;
    private float requiredStayTime = 1f;
    private float minDistance = 0.1f;
    void OnEnable()
    {
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameStart();
        if (gameBar == null || goalBar == null) return;
        valueGoal = Random.Range(0.1f, 0.9f);
        goalBar.value = valueGoal;
        float startValue;
        do
        {
            startValue = Random.Range(0f, 1f);
        } while (Mathf.Abs(startValue - valueGoal) < minDistance);
        gameBar.value = startValue;
        stayTimer = 0f;
        gameBar.onValueChanged.RemoveAllListeners();
        gameBar.onValueChanged.AddListener((v) => stayTimer = 0f);
        SetHandleSprite(normalHandleSprite);
    }
    void Update()
    {
        if (gameBar == null) return;
        bool atGoal = Mathf.Abs(gameBar.value - valueGoal) < 0.01f;
        if (atGoal)
        {
            stayTimer += Time.deltaTime;
            SetHandleSprite(goalHandleSprite);
            if (stayTimer >= requiredStayTime)
            {
                canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameEnd(miniGame);
            }
        }
        else
        {
            stayTimer = 0f;
            SetHandleSprite(normalHandleSprite);
        }
    }
    void SetHandleSprite(Sprite sprite)
    {
        if (gameBar.handleRect != null)
        {
            Image handleImage = gameBar.handleRect.GetComponent<Image>();
            if (handleImage != null && handleImage.sprite != sprite)
            {
                handleImage.sprite = sprite;
            }
        }
    }
}
