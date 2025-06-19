using UnityEngine;
public class pylonBehaviour : MonoBehaviour
{
    // Pylon light toggle settings
    [SerializeField] float interval = 3f;
    [SerializeField] GameObject LightObject;
    // Components and other variables
    private bool isPylonOn = false;
    private float timer = 0f;
    void Update()
    {
        // Toggle the pylon light on and off based on the interval
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            isPylonOn = !isPylonOn;
            timer = 0f;
        }
        if (LightObject != null)
        {
            LightObject.SetActive(isPylonOn);
        }
    }
    public bool getisPylonOn()
    {
        return isPylonOn;
    }
}
