using UnityEngine;

public class universalUIFunctions : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void miniGameStart()
    {
        if (player != null)
        {
            player.GetComponent<playerMovement>()?.MiniGameStart();
        }
    }
    public void miniGameEnd(GameObject miniGame)
    {
        if (miniGame != null)
        {
            player.GetComponent<playerMovement>()?.MiniGameEnd();
            miniGame.SetActive(false);
        }
    }
}
