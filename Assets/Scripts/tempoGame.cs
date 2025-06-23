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
    private readonly float requiredStayTime = 1f;
    private readonly float minDistance = 0.1f;
    public AudioSource Source;
    public AudioClip Clip;
    void OnEnable()
    { // Start the mini-game when this script is enabled
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameStart();
        if (gameBar == null || goalBar == null) return;
        valueGoal = Random.Range(0.1f, 0.9f);
        goalBar.value = valueGoal; // Set the goal value for the game bar
        float startValue;
        do
        {
            startValue = Random.Range(0f, 1f);
        } while (Mathf.Abs(startValue - valueGoal) < minDistance);
        // Ensure the start value is not too close to the goal value
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
        { // If the player is at the goal value
            Source.PlayOneShot(Clip);
            stayTimer += Time.deltaTime;
            SetHandleSprite(goalHandleSprite);
            if (stayTimer >= requiredStayTime)
            { // If the player has stayed at the goal value for the required time
                gameBar.interactable = false;
                canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameEnd(miniGame);
                gameBar.interactable = true;
            }
        }
        else
        { // If the player is not at the goal value
            stayTimer = 0f;
            SetHandleSprite(normalHandleSprite);
        }
    }
    void SetHandleSprite(Sprite sprite)
    { // Set the sprite of the scrollbar handle
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
