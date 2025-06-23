using UnityEngine;
public class pylonBehaviour : MonoBehaviour
{
    [SerializeField] float interval = 3f;
    [SerializeField] GameObject LightObject;
    private bool isPylonOn = false;
    private float timer = 0f;
    public AudioSource Source;
    public AudioClip Clip;
    private bool hasPlayedClip = false;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            // Toggle the pylon state and reset the timer
            isPylonOn = !isPylonOn;
            timer = 0f;
            hasPlayedClip = false;
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
    void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the pylon is on and the collider belongs to the player
        if (isPylonOn && collision.gameObject.CompareTag("Player"))
        {
            if (!hasPlayedClip) // Check if the clip has already been played
            {
                Source.PlayOneShot(Clip);
                hasPlayedClip = true;
            }
            // Apply shock effect to the player
            collision.gameObject.GetComponent<playerMovement>()?.ShockPlayer();
        }
    }
}
