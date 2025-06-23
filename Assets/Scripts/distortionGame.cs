using UnityEngine;
using UnityEngine.UI;
public class distortionGame : MonoBehaviour
{
    [SerializeField] RectTransform canvasRect;
    [SerializeField] GameObject miniGame;
    [SerializeField] Scrollbar[] scrollbars;
    [SerializeField] Scrollbar progressBar;
    [SerializeField] Scrollbar GoalBar;
    [SerializeField] Sprite NormalHandleSprite;
    [SerializeField] Sprite WinHandleSprite;
    private float[] valueGoals;
    public AudioSource Source;
    public AudioClip Clip;
    void OnEnable()
    {
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameStart();
        if (scrollbars == null || scrollbars.Length == 0) return;
        valueGoals = new float[scrollbars.Length]; // Initialize the goals array
        // Initialize each scrollbar with a random value and goal
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
            if (scrollbars[i].handleRect != null)
            {
                Image handleImage = scrollbars[i].handleRect.GetComponent<Image>();
                if (handleImage != null)
                {
                    handleImage.sprite = NormalHandleSprite;
                }
            }
        }
        // Set the goal bar to the first goal value if it exists
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
            bool atGoal = Mathf.Abs(scrollbars[i].value - valueGoals[i]) <= 0.05f;
            if (scrollbars[i].handleRect != null)
            {
                Image handleImage = scrollbars[i].handleRect.GetComponent<Image>();
                if (handleImage != null)
                {
                    Source.PlayOneShot(Clip);
                    handleImage.sprite = atGoal ? WinHandleSprite : NormalHandleSprite;
                }
            }
            if (!atGoal)
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
        // Update the progress bar based on how close each scrollbar is to its goal
        if (progressBar == null) return;
        float totalDistance = 0f;
        for (int i = 0; i < scrollbars.Length; i++)
        {
            totalDistance += Mathf.Abs(scrollbars[i].value - valueGoals[i]);
        }
        float normalized = 1f - Mathf.Clamp01(totalDistance / scrollbars.Length);
        progressBar.value = normalized; // Set the progress bar value based on the average distance to the goals
    }
    private System.Collections.IEnumerator DelayedMiniGameEnd()
    {// Disable all scrollbars and change their handle sprites
        if (scrollbars != null)
        {
            foreach (var sb in scrollbars)
            {
                if (sb != null) sb.interactable = false;
                    if (sb.handleRect != null)
                    {
                        Image handleImage = sb.handleRect.GetComponent<Image>();
                        if (handleImage != null)
                        {
                            handleImage.sprite = WinHandleSprite;
                        }
                    }
            }
        }
        yield return new WaitForSeconds(1f);
        // Re-enable all scrollbars and reset their handle sprites
            foreach (var sb in scrollbars)
            {
            if (sb != null) sb.interactable = true;
                if (sb.handleRect != null)
                {
                    Image handleImage = sb.handleRect.GetComponent<Image>();
                    if (handleImage != null)
                    {
                        handleImage.sprite = NormalHandleSprite;
                    }
                }
            }
        canvasRect.gameObject.GetComponent<universalUIFunctions>().miniGameEnd(miniGame);
    }
}