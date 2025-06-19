using UnityEngine;
public class pylonAnimation : MonoBehaviour
{
    // Pylon animation sprites
    [SerializeField] Sprite[] pylonOnSprites;
    [SerializeField] Sprite[] pylonOffSprites;
    // Animation settings
    [SerializeField] float animationFrameRate = 10f;
    // Components and other variables
    private SpriteRenderer spriteRenderer;
    private float frameTimer;
    private int currentFrame;
    private Sprite[] currentAnimation;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // Check if the pylon is on or off
        bool isPylonOn = GetComponent<pylonBehaviour>().getisPylonOn();
        currentAnimation = isPylonOn ? pylonOnSprites : pylonOffSprites;
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
        else
        {
            spriteRenderer.sprite = null;
        }
    }
}
