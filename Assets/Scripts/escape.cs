using UnityEngine;
public class escape : MonoBehaviour
{
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { // If the Escape key is pressed, quit the application
            Application.Quit();
        }
    }
}
