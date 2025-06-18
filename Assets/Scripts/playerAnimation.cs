using UnityEngine;
public class playerAnimation : MonoBehaviour
{
    // Player animation sprites
    [SerializeField] Sprite[] backSprite;
    [SerializeField] Sprite[] frontSprite;
    [SerializeField] Sprite[] sideSprite;
    [SerializeField] float animationFrameRate;
    // Components and other variables
    private SpriteRenderer spriteRenderer;
    private float frameTimer;
    private int currentFrame;
    private Sprite[] currentAnimation;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentAnimation = frontSprite;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // Choose animation based on input
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
        // Animate
        if (currentAnimation != null && currentAnimation.Length > 0)
        {
            frameTimer += Time.deltaTime;
            if (frameTimer >= 1f / animationFrameRate)
            {
                frameTimer = 0f;
                currentFrame = (currentFrame + 1) % currentAnimation.Length;
                spriteRenderer.sprite = currentAnimation[currentFrame];
            }
        }
        if(horizontal == 0 && vertical == 0)
        {
            currentFrame = 0;
            spriteRenderer.sprite = currentAnimation[currentFrame];
        }
    }
}
