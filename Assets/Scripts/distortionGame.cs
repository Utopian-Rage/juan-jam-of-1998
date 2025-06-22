using UnityEngine;
using UnityEngine.UI;
public class distortionGame : MonoBehaviour
{
    [SerializeField] RectTransform canvasRect;
    [SerializeField] GameObject miniGame;
    [SerializeField] Scrollbar[] scrollbars;
    [SerializeField] Scrollbar progressBar;
    [SerializeField] Scrollbar GoalBar;
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
            if (GoalBar != null && scrollbars.Length == 1)
            {
                GoalBar.value = valueGoals[i];
            }
        }
        if (GoalBar != null && scrollbars.Length > 0)
        {
            GoalBar.value = valueGoals[0];
        }
        UpdateProgressBar();
    }
    void CheckWinCondition()
    {
        bool allAtGoal = true;
        for (int i = 0; i < scrollbars.Length; i++)
        {
            if (Mathf.Abs(scrollbars[i].value - valueGoals[i]) > 0.05f)
                allAtGoal = false;
        }
        UpdateProgressBar();
        if (allAtGoal)
        {
            for (int i = 0; i < scrollbars.Length; i++)
            {
                scrollbars[i].value = valueGoals[i];
            }
            StartCoroutine(DelayedMiniGameEnd());
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
    private System.Collections.IEnumerator DelayedMiniGameEnd()
    {
        if (scrollbars != null)
        {
            foreach (var sb in scrollbars)
            {
                if (sb != null) sb.interactable = false;
            }
        }
        yield return new WaitForSeconds(1f);
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameEnd(miniGame);
    }
}