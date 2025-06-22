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
                    interactableChild.gameObject.SetActive(false);
                }
            }
            if (miniGame != null)
                miniGame.SetActive(true);
            isPlayerInTrigger = false;
            isTimerDone = false;
            StartCoroutine(StartInteractionTimer());
        }
    }
    private System.Collections.IEnumerator StartInteractionTimer()
    {
        Debug.Log("Interaction started, waiting for " + timerDuration + " seconds.");
        yield return new WaitForSeconds(timerDuration);
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
