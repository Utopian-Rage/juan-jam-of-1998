using UnityEngine;
public class timeButton : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    [SerializeField] float timeToAdd = 10f;
    levelTimer timer;
    public AudioSource Source;
    public AudioClip Clip;
    public AudioClip Clip2;
    void Start()
    {
        GameObject levelTimerObject = GameObject.Find("LevelTimer");
        if (levelTimerObject == null)
        {
            Debug.LogWarning("LevelTimer object not found.");
            return;
        }
        timer = levelTimerObject.GetComponent<levelTimer>();
    }
    void Update()
    {
        if (isPlayerInTrigger && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Submit")))
        { // Check if the player is in the trigger and presses the interact key
        // Play the audio clips (maybe just one if you prefer? - LK)
            Source.PlayOneShot(Clip);
            Source.PlayOneShot(Clip2);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Transform interactableChild = player.transform.Find("Interactable");
                if (interactableChild != null)
                {
                    interactableChild.gameObject.SetActive(false);
                }
            }
            if (timer != null)
            { // If the level timer is found, add time
                timer.AddTime(timeToAdd);
            }
            else
            {
                Debug.LogWarning("LevelTimer was not found.");
            }
            isPlayerInTrigger = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            Transform interactableChild = collision.transform.Find("Interactable");
            if (interactableChild != null)
            { // If the player is in the trigger, enable the interactable notification
                interactableChild.gameObject.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            Transform interactableChild = collision.transform.Find("Interactable");
            if (interactableChild != null)
            { // If the player exits the trigger, disable the interactable notification
                interactableChild.gameObject.SetActive(false);
            }
        }
    }
}
