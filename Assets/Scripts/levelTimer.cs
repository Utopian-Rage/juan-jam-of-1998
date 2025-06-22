using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelTimer : MonoBehaviour
{
    [Tooltip("Timer is in seconds")]
    [SerializeField] float gameTime = 5f;
    [SerializeField] TextMeshProUGUI timerText;
    private float timeRemaining;
    private bool isTimerRunning = false;
    void OnEnable()
    {
        StartTimer();
    }

    void StartTimer()
    {
        timeRemaining = gameTime;
        isTimerRunning = true;
        UpdateTimerText();
    }
    void Update()
    {
        if (isTimerRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isTimerRunning = false;
                Debug.Log("Timer has ended!");
                SceneManager.LoadScene("Level 2");
            }
            UpdateTimerText();
        }
    }
    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void AddTime(float additionalTime)
    {
        if (isTimerRunning)
        {
            timeRemaining += additionalTime;
            UpdateTimerText();
        }
    }
}
