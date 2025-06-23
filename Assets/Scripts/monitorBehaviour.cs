using UnityEngine;
public class monitorBehaviour : MonoBehaviour
{
    [SerializeField] Sprite MonitorSpriteOn;
    [SerializeField] Sprite MonitorSpriteOff;
    [SerializeField] float timerDuration = 2f;
    void OnEnable()
    {
        // Start the monitor when the script is enabled
        GameObject monitorObj = GameObject.Find("Monitor");
        if (monitorObj != null)
        {
            // Set the monitor sprite to "on" state
            SpriteRenderer sr = monitorObj.GetComponent<SpriteRenderer>();
            if (sr != null && MonitorSpriteOn != null)
            {
                sr.sprite = MonitorSpriteOn;
            }
        }
        Invoke(nameof(EndMonitor), timerDuration);
        // Do any additional things here while the monitor is enabled
        // For example, you could play a sound
    }
    // Update is called once per frame
    // This method is not necessary for the current functionality, but can be used for future updates
    void Update()
    {
        
    }
    // This method is called to end the monitor after the timer duration has passed
    // It sets the monitor sprite to "off" state and deactivates the game object
    void EndMonitor()
    {
        GameObject monitorObj = GameObject.Find("Monitor");
        if (monitorObj != null)
        {
            SpriteRenderer sr = monitorObj.GetComponent<SpriteRenderer>();
            if (sr != null && MonitorSpriteOff != null)
            {
                sr.sprite = MonitorSpriteOff;
            }
        }
        gameObject.SetActive(false);
    }
}