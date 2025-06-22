using UnityEngine;
public class timeButton : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    [SerializeField] float timeToAdd = 10f;
    levelTimer timer;
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
        {
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
            {
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
            {
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
            {
                interactableChild.gameObject.SetActive(false);
            }
        }
    }
}
