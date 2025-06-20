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
    private bool waitForAllOn = true;
    void OnEnable()
    {
        if (targetButton == null || targetButton.Length == 0 || canvasRect == null) return;
        isOn = new bool[targetButton.Length];
        int onCount = 0, offCount = 0;

        for (int i = 0; i < targetButton.Length; i++)
        {
            isOn[i] = Random.value > 0.5f;
            if (isOn[i]) onCount++; else offCount++;
            targetButton[i].GetComponent<Image>().color = isOn[i] ? Color.green : Color.red;
            int idx = i;
            targetButton[i].onClick.RemoveAllListeners();
            targetButton[i].onClick.AddListener(() => ToggleButton(idx));
        }
        waitForAllOn = offCount > onCount;
    }
    void ToggleButton(int idx)
    {
        isOn[idx] = !isOn[idx];
        targetButton[idx].GetComponent<Image>().color = isOn[idx] ? Color.green : Color.red;
        CheckWinCondition();
    }
    void CheckWinCondition()
    {
        bool allOn = true, allOff = true;
        for (int i = 0; i < isOn.Length; i++)
        {
            if (!isOn[i]) allOn = false;
            if (isOn[i]) allOff = false;
        }

        if (waitForAllOn && allOn)
        {
            miniGameEnd();
        }
        else if (!waitForAllOn && allOff)
        {
            miniGameEnd();
        }
    }
    public void miniGameEnd()
    {
        if (miniGame != null)
        {
            miniGame.SetActive(false);
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