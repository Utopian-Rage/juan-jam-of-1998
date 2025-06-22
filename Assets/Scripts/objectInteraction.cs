using UnityEngine;
public class objectInteraction : MonoBehaviour
{
    [SerializeField] Canvas uiCanvas;
    [SerializeField] GameObject miniGame;
    private bool isPlayerInTrigger = false;
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
            if (uiCanvas != null)
                uiCanvas.gameObject.SetActive(true);

            if (miniGame != null)
                miniGame.SetActive(true);
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
