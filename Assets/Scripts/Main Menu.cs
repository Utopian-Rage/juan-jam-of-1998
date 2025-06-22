using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioClip MainTheme;

    private AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void PlayGame()
    {
        AudioSource.Stop();
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        AudioSource.Stop();
        Application.Quit();
    }
}
