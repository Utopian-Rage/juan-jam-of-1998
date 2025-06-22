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
    void OnEnable()
    {
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameStart();
        if (targetButton == null || targetButton.Length == 0 || canvasRect == null) return;
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
        }
    }
    void ToggleButton(int idx)
    {
        isOn[idx] = !isOn[idx];
        UpdateButtonVisual(idx);
        CheckWinCondition();
    }
    void UpdateButtonVisual(int idx)
    {
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
    {
        for (int i = 0; i < isOn.Length; i++)
        {
            if (!isOn[i])
                return;
        }
        StartCoroutine(DelayedMiniGameEnd());
    }
    private System.Collections.IEnumerator DelayedMiniGameEnd()
    {
        foreach (var btn in targetButton)
        {
            if (btn != null) btn.interactable = false;
        }
        yield return new WaitForSeconds(1f);
        foreach (var btn in targetButton)
        {
            if (btn != null) btn.interactable = true;
        }
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameEnd(miniGame);
    }
}