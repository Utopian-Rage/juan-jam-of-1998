using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {
        Input.GetKeyDown(KeyCode.Escape);
            Application.Quit();
    }
    public void PlayGame()
    {
        AudioSource.Stop();
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        AudioSource.Stop();
        Application.Quit();
    }
}
