using UnityEngine;

public class universalUIFunctions : MonoBehaviour
{
    public void miniGameEnd(GameObject miniGame)
    {
        if (miniGame != null)
        {
            miniGame.SetActive(false);
        }
    }
}
