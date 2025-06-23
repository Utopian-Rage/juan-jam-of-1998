using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class delayGame : MonoBehaviour
{
    [SerializeField] float gameTime = 5f;
    [SerializeField] Button[] targetButton;
    [SerializeField] RectTransform canvasRect;
    [SerializeField] GameObject miniGame;
    [SerializeField] Sprite onButton;
    [SerializeField] Sprite offButton;
    [SerializeField] TextMeshProUGUI timerText;
    private bool[] isOn;
    private Coroutine gameTimerCoroutine;
    public AudioSource Source;
    public AudioClip Clip;
    void OnEnable()
    {
        Gameinitialisation();
    }
    void Gameinitialisation()
    {
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameStart();
        if (targetButton == null || targetButton.Length == 0 || canvasRect == null) return;
        // Initialize the isOn array and set up the buttons
        isOn = new bool[targetButton.Length];
        int total = targetButton.Length;
        int minOff = Mathf.CeilToInt(total / 2f);
        int offCount = 0;
        for (int i = 0; i < total; i++)
        {
            isOn[i] = false;
        }
        for (int i = 0; i < total; i++)
        {
            if (offCount < minOff)
            {
                offCount++;
            }
            else
            {
                isOn[i] = Random.value > 0.5f;
            }
        }
        for (int i = 0; i < total; i++)
        {
            int swapIdx = Random.Range(0, total);
            bool temp = isOn[i];
            isOn[i] = isOn[swapIdx];
            isOn[swapIdx] = temp;
        }
        for (int i = 0; i < total; i++)
        {
            UpdateButtonVisual(i);
            int idx = i;
            targetButton[i].onClick.RemoveAllListeners();
            targetButton[i].onClick.AddListener(() => ToggleButton(idx));
            targetButton[i].interactable = !isOn[i];
        }
        if (gameTimerCoroutine != null)
            StopCoroutine(gameTimerCoroutine);
        // Start the game timer coroutine
        gameTimerCoroutine = StartCoroutine(GameTimer());
    }
    void ToggleButton(int idx)
    {
        Source.PlayOneShot(Clip);
        isOn[idx] = !isOn[idx];
        UpdateButtonVisual(idx);
        CheckWinCondition();
    }
    void UpdateButtonVisual(int idx)
    {
        // Update the button's visual state based on isOn[idx]
        Image buttonImage = targetButton[idx].GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = isOn[idx] ? onButton : offButton;
        }
        targetButton[idx].interactable = !isOn[idx];
    }
    void CheckWinCondition()
    {
        // Check if all buttons are turned on
        for (int i = 0; i < isOn.Length; i++)
        {
            if (!isOn[i])
                return;
        }
        // If all buttons are on, end the game
        foreach (var btn in targetButton)
        {
            if (btn != null) btn.interactable = false;
        }
        StopAllCoroutines();
        StartCoroutine(DelayedMiniGameEnd());
    }
    private System.Collections.IEnumerator DelayedMiniGameEnd()
    {
        // Wait for a short delay before ending the mini game
        foreach (var btn in targetButton)
        {
            if (btn != null) btn.interactable = false;
        }
        yield return new WaitForSeconds(1f);
        foreach (var btn in targetButton)
        {
            if (btn != null) btn.interactable = true; // Re-enable buttons for the end state
        }
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameEnd(miniGame);
    }
    private System.Collections.IEnumerator GameTimer()
    {
        // Start the game timer
        float timer = gameTime;
        while (timer > 0f)
        {
            if (timerText != null)
            {
                int minutes = Mathf.FloorToInt(timer / 60f);
                int seconds = Mathf.FloorToInt(timer % 60f);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            yield return null;
            timer -= Time.deltaTime;
        }
        // Timer has run out, reset the game
        if (timerText != null)
            timerText.text = "00:00";
        ResetGame();
    }
    void ResetGame()
    {
        // Reset the game state
        Gameinitialisation();
    }
}
