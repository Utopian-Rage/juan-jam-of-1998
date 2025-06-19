using UnityEngine;
public class objectInteraction : MonoBehaviour
{
    // Object interaction settings
    [SerializeField] Canvas uiCanvas;
    [SerializeField] GameObject miniGame;
    // Components and other variables
    private bool isPlayerInTrigger = false;
    void Update()
    {
        // Check if the player is in the trigger area and presses the interaction key
        if (isPlayerInTrigger && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Submit")))
        {
            if (uiCanvas != null)
                uiCanvas.gameObject.SetActive(true);

            if (miniGame != null)
                miniGame.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player has entered the trigger area
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            Debug.Log("Player entered trigger area. Press 'E' to interact.");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}
