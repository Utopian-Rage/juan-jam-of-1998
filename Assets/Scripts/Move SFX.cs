using UnityEngine;
public class MoveSFX : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Clip;
    public AudioClip Clip2;
    private bool playClip1Next = true;

    [SerializeField] playerAnimation playerAnim; // Assign in Inspector or via GetComponent

    private int lastFrame = -1;

    private void Start()
    {
        if (playerAnim == null)
            playerAnim = Object.FindFirstObjectByType<playerAnimation>();
    }

    private void Update()
    {
        if (playerAnim == null)
            return;

        // Only play SFX if moving (not paused or shocked)
        if (IsMoving() && !IsPausedOrShocked())
        {
            int currentFrame = playerAnim.GetCurrentFrame();
            if (currentFrame != lastFrame)
            {
                // Only play a new clip if the previous one has finished
                if (!Source.isPlaying)
                {
                    Source.clip = playClip1Next ? Clip : Clip2;
                    Source.Play();
                    playClip1Next = !playClip1Next;
                    lastFrame = currentFrame;
                }
            }
        }
        else
        {
            lastFrame = -1; // Reset so SFX can play again when movement resumes
        }
    }

    private bool IsMoving()
    {
        return Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.01f;
    }

    private bool IsPausedOrShocked()
    {
        // Access isPaused and isShocked via public methods or properties
        return playerAnim.IsPaused() || playerAnim.IsShocked();
    }
}