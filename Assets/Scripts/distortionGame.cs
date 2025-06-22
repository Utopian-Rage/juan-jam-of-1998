using UnityEngine;
using UnityEngine.UI;
public class distortionGame : MonoBehaviour
{
    [SerializeField] RectTransform canvasRect;
    [SerializeField] GameObject miniGame;
    [SerializeField] Scrollbar[] scrollbars;
    [SerializeField] Scrollbar progressBar;
    private float[] valueGoals;
    void OnEnable()
    {
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameStart();
        if (scrollbars == null || scrollbars.Length == 0) return;

        valueGoals = new float[scrollbars.Length];

        for (int i = 0; i < scrollbars.Length; i++)
        {
            valueGoals[i] = Random.Range(0f, 1f);
            scrollbars[i].value = Random.Range(0f, 1f);
            int idx = i;
            scrollbars[i].onValueChanged.RemoveAllListeners();
            scrollbars[i].onValueChanged.AddListener((v) => CheckWinCondition());
        }
        UpdateProgressBar();
    }
    void CheckWinCondition()
    {
        bool allAtGoal = true;
        for (int i = 0; i < scrollbars.Length; i++)
        {
            if (Mathf.Abs(scrollbars[i].value - valueGoals[i]) > 0.1f)
                allAtGoal = false;
        }
        UpdateProgressBar();
        if (allAtGoal)
        {
            canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameEnd(miniGame);
        }
    }
    void UpdateProgressBar()
    {
        if (progressBar == null) return;
        float totalDistance = 0f;
        for (int i = 0; i < scrollbars.Length; i++)
        {
            totalDistance += Mathf.Abs(scrollbars[i].value - valueGoals[i]);
        }
        float normalized = 1f - Mathf.Clamp01(totalDistance / scrollbars.Length);
        progressBar.value = normalized;
    }
}