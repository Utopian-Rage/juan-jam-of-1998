using UnityEngine;
using UnityEngine.UI;
public class switchesGame : MonoBehaviour
{
    [SerializeField] Button[] targetButton;
    [SerializeField] RectTransform canvasRect;
    [SerializeField] GameObject miniGame;
    [SerializeField] Sprite onButton;
    [SerializeField] Sprite ofButton;
    [SerializeField] Texture onLight;
    [SerializeField] Texture ofLight;
    private bool[] isOn;
    public AudioSource Source;
    public AudioClip Clip;
    void OnEnable()
    {
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameStart();
        if (targetButton == null || targetButton.Length == 0 || canvasRect == null) return;
        // Initialize the game state
        isOn = new bool[targetButton.Length]; // Create an array to track the state of each button
        int total = targetButton.Length; // Get the total number of buttons
        int minOff = Mathf.CeilToInt(total / 2f);
        int offCount = 0;
        for (int i = 0; i < total; i++)
        {
            isOn[i] = false;
        }
        for (int i = 0; i < total; i++)
        { // Randomly set the initial state of each button
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
        { // Shuffle the buttons to randomize their initial state
            int swapIdx = Random.Range(0, total);
            bool temp = isOn[i];
            isOn[i] = isOn[swapIdx];
            isOn[swapIdx] = temp;
        }
        for (int i = 0; i < total; i++)
        { // Update the visual state of each button based on the initial state
            UpdateButtonVisual(i); 
            int idx = i;
            targetButton[i].onClick.RemoveAllListeners();
            targetButton[i].onClick.AddListener(() => ToggleButton(idx));
        }
    }
    void ToggleButton(int idx)
    { // Toggle the state of the button at the specified index
        Source.PlayOneShot(Clip);
        isOn[idx] = !isOn[idx];
        UpdateButtonVisual(idx);
        CheckWinCondition();
    }
    void UpdateButtonVisual(int idx)
    { // Update the visual representation of the button based on its state
        Image buttonImage = targetButton[idx].GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = isOn[idx] ? onButton : ofButton;
        }
        RawImage childRawImage = targetButton[idx].GetComponentInChildren<RawImage>();
        if (childRawImage != null)
        {
            childRawImage.texture = isOn[idx] ? onLight : ofLight;
        }
    }
    void CheckWinCondition()
    { // Check if all buttons are in the "on" state
        for (int i = 0; i < isOn.Length; i++)
        {
            if (!isOn[i])
                return;
        }
        StartCoroutine(DelayedMiniGameEnd());
    }
    private System.Collections.IEnumerator DelayedMiniGameEnd()
    { // Delay the end of the mini game to allow for visual feedback
        foreach (var btn in targetButton)
        {
            if (btn != null) btn.interactable = false;
        }
        yield return new WaitForSeconds(1f);
        // After the delay, set all buttons to interactable and end the mini game. This prevents the buttons being disabled when the mini game is restarted.
        foreach (var btn in targetButton)
        {
            if (btn != null) btn.interactable = true;
        }
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameEnd(miniGame);
    }
}