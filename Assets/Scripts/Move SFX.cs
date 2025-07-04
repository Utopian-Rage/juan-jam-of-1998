using UnityEngine;
public class MoveSFX : MonoBehaviour
{
    [SerializeField] AudioSource Source;
    [SerializeField] AudioClip Clip;
    [SerializeField] AudioClip Clip2;
    [SerializeField] playerAnimation playerAnim;
    private bool playClip1Next = true;
    private bool hasMoved = false;

    private int lastFrame = -1;

    private void Update()
    {
        if (playerAnim == null)
            return;
        // Detect first movement
        if (!hasMoved && IsMoving())
        {
            hasMoved = true;
        }
        // Only play SFX if moving (not paused or shocked) and player has moved at least once
        if (hasMoved && IsMoving() && !IsPausedOrShocked())
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
        // Check if the player is moving based on input axes
        return Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.01f;
    }
    private bool IsPausedOrShocked()
    {
        // Access isPaused and isShocked via public methods or properties
        return playerAnim.IsPaused() || playerAnim.IsShocked();
    }
}