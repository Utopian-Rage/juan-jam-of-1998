using UnityEngine;
public class monitorInteraction : MonoBehaviour
{
    [SerializeField] GameObject miniGame;
    private bool isPlayerInTrigger = false;
    public AudioSource Source;
    public AudioClip Clip;
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
                    // disable the interactable sprite when the player interacts
                    interactableChild.gameObject.SetActive(false);
                }
            }
            if (miniGame != null)
            {
                miniGame.SetActive(true);
                isPlayerInTrigger = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Player has entered the trigger area
            isPlayerInTrigger = true;
            Transform interactableChild = collision.transform.Find("Interactable");
            if (interactableChild != null)
            {
                // enable the interactable sprite when the player enters the trigger
                interactableChild.gameObject.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Player has exited the trigger area
            isPlayerInTrigger = false;
            Transform interactableChild = collision.transform.Find("Interactable");
            if (interactableChild != null)
            {
                // disable the interactable sprite when the player exits the trigger
                interactableChild.gameObject.SetActive(false);
            }
        }
    }
}
