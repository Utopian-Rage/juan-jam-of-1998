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
