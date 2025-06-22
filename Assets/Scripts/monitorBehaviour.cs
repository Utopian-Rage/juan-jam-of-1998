using UnityEngine;
public class monitorBehaviour : MonoBehaviour
{
    [SerializeField] Sprite MonitorSpriteOn;
    [SerializeField] Sprite MonitorSpriteOff;
    [SerializeField] float timerDuration = 2f;
    void OnEnable()
    {
        GameObject monitorObj = GameObject.Find("Monitor");
        if (monitorObj != null)
        {
            SpriteRenderer sr = monitorObj.GetComponent<SpriteRenderer>();
            if (sr != null && MonitorSpriteOn != null)
            {
                sr.sprite = MonitorSpriteOn;
            }
        }
        Invoke(nameof(EndMonitor), timerDuration);
    }
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