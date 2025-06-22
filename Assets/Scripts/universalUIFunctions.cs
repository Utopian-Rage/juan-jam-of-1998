using UnityEngine;

public class universalUIFunctions : MonoBehaviour
{
    GameObject player;
    playerMovement playerMovementScript;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerMovementScript = player.GetComponent<playerMovement>();
            if (playerMovementScript == null)
            {
                Debug.LogWarning("playerMovement script not found.");
            }
        }
        else
        {
            Debug.LogWarning("Player object not found.");
        }
    }
    public void miniGameStart()
    {
        if (player != null)
        {
            playerMovementScript.MiniGameStart();
        }
    }
    public void miniGameEnd(GameObject miniGame)
    {
        if (miniGame != null)
        {
            playerMovementScript.MiniGameEnd();
            miniGame.SetActive(false);
        }
    }
}
