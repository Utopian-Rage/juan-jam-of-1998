using UnityEngine;
using UnityEngine.UI;

public class switchesGame : MonoBehaviour
{
    [SerializeField] Button[] targetButton;
    [SerializeField] RectTransform canvasRect;
    [SerializeField] GameObject miniGame;
    /*[Header("Horizontal")]
    [SerializeField] float minX, maxX;
    [Header("Vertical")]
    [SerializeField] float minY, maxY;*/
    private bool[] isOn;
    void OnEnable()
    {
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
        targetButton[idx].GetComponent<Image>().color = isOn[idx] ? Color.green : Color.red;
        RawImage childRawImage = targetButton[idx].GetComponentInChildren<RawImage>();
        if (childRawImage != null)
        {
            childRawImage.color = isOn[idx] ? Color.white : Color.black;
        }
    }
    void CheckWinCondition()
    {
        for (int i = 0; i < isOn.Length; i++)
        {
            if (!isOn[i])
                return;
        }
    }
    /*void OnEnable()
    {
        
        if (targetButton == null || canvasRect == null) return;

        for (int i = 0; i < targetButton.Length; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            RectTransform buttonRect = targetButton[i].GetComponent<RectTransform>();
            buttonRect.anchoredPosition = new Vector2(randomX, randomY);
        }
        
    }*/
}