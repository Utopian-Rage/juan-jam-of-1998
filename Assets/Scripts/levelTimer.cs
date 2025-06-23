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
        // Ensure the timer is reset and started
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
                levelTimerEnd(); // Call the method to handle timer end
            }
            UpdateTimerText();
        }
        else return; // If the timer is not running, do nothing
    }
    void UpdateTimerText()
    {
        // Update the timer text display
        if (timerText == null) return; // Ensure timerText is assigned
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void AddTime(float additionalTime)
    {
        // Add additional time to the timer if it is running
        if (isTimerRunning)
        {
            timeRemaining += additionalTime;
            UpdateTimerText();
        }
    }
    void levelTimerEnd()
    {
        // Set the timer to 0
        timeRemaining = 0;
        isTimerRunning  = false;
        UpdateTimerText();
        // Handle the end of the timer, such as transitioning to a new scene or showing a game over screen
        Debug.Log("Level timer ended.");
        // SceneManager.LoadScene("Replace with your desired scene name");
    }
}
