using UnityEngine;
public class musicplayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] musicClips;
    private int currentIndex = 0;
    void OnEnable()
    {
        if (musicClips != null && musicClips.Length > 0)
        {
            currentIndex = Random.Range(0, musicClips.Length);
        }
    }
    void Start()
    {
        if (musicClips != null && musicClips.Length > 0)
        {
            PlayCurrent();
        }
    }
    void Update()
    {
        if (musicClips != null && musicClips.Length > 0 && audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                currentIndex = (currentIndex + 1) % musicClips.Length;
                PlayCurrent();
            }
        }
    }
    private void PlayCurrent()
    {
        audioSource.Stop();
        audioSource.clip = musicClips[currentIndex];
        audioSource.Play();
    }
}