using UnityEngine;
public class objectInteraction : MonoBehaviour
{
    [SerializeField] GameObject miniGame;
    [SerializeField] float timerDuration = 2f;
    private bool isPlayerInTrigger = false;
    bool isTimerDone = true;
    void Update()
    {
        if (isTimerDone && isPlayerInTrigger && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Submit")))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Transform interactableChild = player.transform.Find("Interactable");
                if (interactableChild != null)
                {
                    // Disable the interactable sprite when the player interacts
                    interactableChild.gameObject.SetActive(false);
                }
            }
            if (miniGame != null)
                miniGame.SetActive(true); // Activate the mini game
            isPlayerInTrigger = false; // Reset the trigger state
            isTimerDone = false; // Set the timer to not done
            StartCoroutine(StartInteractionTimer()); // Start the interaction timer (I'm planning to find a way to start this when the mini game is closed - LK)
        }
    }
    private System.Collections.IEnumerator StartInteractionTimer()
    {
        Debug.Log("Interaction started, waiting for " + timerDuration + " seconds.");
        yield return new WaitForSeconds(timerDuration); // Wait for the specified duration
        // After the wait, set the timer as done
        isTimerDone = true;
        Debug.Log("Interaction timer done.");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isTimerDone)
        {
            isPlayerInTrigger = true;
            Transform interactableChild = collision.transform.Find("Interactable");
            if (interactableChild != null)
            {
                // Enable the interactable sprite when the player enters the trigger
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
                // Disable the interactable sprite when the player exits the trigger
                interactableChild.gameObject.SetActive(false);
            }
        }
    }
}
