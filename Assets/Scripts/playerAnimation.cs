using UnityEngine;
public class playerAnimation : MonoBehaviour
{
    [SerializeField] Sprite[] backSprite;
    [SerializeField] Sprite[] frontSprite;
    [SerializeField] Sprite[] sideSprite;
    [SerializeField] Sprite[] shockedSprite;
    [SerializeField] Sprite[] endShockedSprite;
    [SerializeField] float animationFrameRate;
    private SpriteRenderer spriteRenderer;
    private float frameTimer;
    private int currentFrame;
    private Sprite[] currentAnimation;
    private bool isShocked = false;
    private bool isEndShocked = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentAnimation = frontSprite;
    }
    void Update()
    {
        if (isShocked)
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
        if (isEndShocked)
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
            if (frameTimer >= 1f / animationFrameRate)
            {
                //Will put walk SFX here for walking animation - LS
                frameTimer = 0f;
                currentFrame = (currentFrame + 1) % currentAnimation.Length;
                spriteRenderer.sprite = currentAnimation[currentFrame];
            }
        }
        if (horizontal == 0 && vertical == 0)
        {
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
        private void EndEndShocked()
    {
        isEndShocked = false;
        currentFrame = 0;
        frameTimer = 0f;
    }
}
