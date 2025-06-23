using UnityEngine;
using UnityEngine.Audio;
public class playerAnimation : MonoBehaviour
{
    [SerializeField] Sprite[] backSprite;
    [SerializeField] Sprite[] frontSprite;
    [SerializeField] Sprite[] sideSprite;
    [SerializeField] Sprite[] shockedSprite;
    [SerializeField] Sprite[] endShockedSprite;
    // The backSprite, frontSprite, sideSprite, ShockedSprite, and endShockedSprite arrays should contain the sprites for the respective animations
    [SerializeField] float animationFrameRate;
    // The animationFrameRate is the number of frames per second for the animation
    // For example, if you want 10 frames per second, set this to 10
    private SpriteRenderer spriteRenderer;
    private float frameTimer;
    private int currentFrame;
    private Sprite[] currentAnimation;
    private bool isShocked = false;
    private bool isEndShocked = false;
    private bool isPaused = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentAnimation = frontSprite;
    }
    void Update()
    {
        if (isPaused) // If the animations are paused, set the sprite to the first animation frame of it's last state
        {
            if (isShocked && shockedSprite != null && shockedSprite.Length > 0)
            {
                spriteRenderer.sprite = shockedSprite[0];
            }
            else if (isEndShocked && endShockedSprite != null && endShockedSprite.Length > 0)
            {
                spriteRenderer.sprite = endShockedSprite[0];
            }
            else if (currentAnimation != null && currentAnimation.Length > 0)
            {
                spriteRenderer.sprite = currentAnimation[0];
            }
            return;
        }
        if (isShocked) // If the player is shocked, play the shocked animation
        {
            if (shockedSprite != null && shockedSprite.Length > 0)
            {
                frameTimer += Time.deltaTime;
                if (frameTimer >= 1f / animationFrameRate)
                {
                    frameTimer = 0f;
                    currentFrame = (currentFrame + 1) % shockedSprite.Length;
                    spriteRenderer.sprite = shockedSprite[currentFrame];
                }
            }
            return;
        }
        if (isEndShocked) // If the player is in the end shocked state, play the end shocked animation
        {
            if (endShockedSprite != null && endShockedSprite.Length > 0)
            {
                frameTimer += Time.deltaTime;
                if (frameTimer >= 1f / animationFrameRate)
                {
                    frameTimer = 0f;
                    currentFrame = (currentFrame + 1) % endShockedSprite.Length;
                    spriteRenderer.sprite = endShockedSprite[currentFrame];
                }
            }
            return;
        }
        // If the player is not shocked, play the normal movement animations
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal < 0)
        {
            currentAnimation = sideSprite;
            spriteRenderer.flipX = false;
        }
        else if (horizontal > 0)
        {
            currentAnimation = sideSprite;
            spriteRenderer.flipX = true;
        }
        else if (vertical < 0)
        {
            currentAnimation = frontSprite;
            spriteRenderer.flipX = false;
        }
        else if (vertical > 0)
        {
            currentAnimation = backSprite;
            spriteRenderer.flipX = false;
        }
        if (currentAnimation != null && currentAnimation.Length > 0)
        {
            frameTimer += Time.deltaTime;
            if (frameTimer >= 1f / animationFrameRate) // Check if it's time to switch to the next frame
            {
                frameTimer = 0f;
                currentFrame = (currentFrame + 1) % currentAnimation.Length;
                spriteRenderer.sprite = currentAnimation[currentFrame];
            }
        }
        if (horizontal == 0 && vertical == 0)
        {
            // If the player is not moving, reset to the first frame of the current animation
            currentFrame = 0;
            spriteRenderer.sprite = currentAnimation[currentFrame];
        }
    }
    public void PlayShocked()
    {
        isShocked = true;
        currentFrame = 0;
        frameTimer = 0f;
    }
    public void StopShocked()
    {
        isShocked = false;
        currentFrame = 0;
        frameTimer = 0f;
    }
    public void PauseAnimations()
    {
        isPaused = true;
    }
    public void ResumeAnimations()
    {
        isPaused = false;
    }
    public int GetCurrentFrame()
    {
        return currentFrame;
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public bool IsShocked()
    {
        return isShocked;
    }
}
