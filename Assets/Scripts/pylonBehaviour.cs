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
        if (isPylonOn && collision.gameObject.CompareTag("Player"))
        {
            if (!hasPlayedClip)
            {
                Source.PlayOneShot(Clip);
                hasPlayedClip = true;
            }
            collision.gameObject.GetComponent<playerMovement>()?.ShockPlayer();
        }
    }
}
