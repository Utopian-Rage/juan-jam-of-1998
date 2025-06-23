using UnityEngine;
// This script provides universal UI functions for mini-games
// It handles starting and ending mini-games, and interacts with the player movement script.
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
        // Start the mini-game by calling the MiniGameStart method on the playerMovement script
        if (player != null)
        {
            playerMovementScript.MiniGameStart();
        }
    }
    public void miniGameEnd(GameObject miniGame)
    {
        // End the mini-game by calling the MiniGameEnd method on the playerMovement script
        if (miniGame != null)
        {
            playerMovementScript.MiniGameEnd();
            miniGame.SetActive(false); // Deactivate the mini-game object
        }
    }
}
