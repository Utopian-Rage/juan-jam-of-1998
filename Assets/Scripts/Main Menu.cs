using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioClip MainTheme;

    private AudioSource AudioSource;

    private void Start()
    {
        // Play the main theme audio on start
        AudioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { // If the Escape key is pressed, quit the application
            QuitGame();
        }
    }
    public void PlayGame()
    {
        // Load the first level when the Play button is clicked
        AudioSource.Stop();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // Stop the audio and quit the application when the Quit button is clicked
        AudioSource.Stop();
        Application.Quit();
    }
}
