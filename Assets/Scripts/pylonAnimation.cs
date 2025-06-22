using UnityEngine;
public class pylonAnimation : MonoBehaviour
{
    [SerializeField] Sprite[] pylonOnSprites;
    [SerializeField] Sprite[] pylonOffSprites;
    [SerializeField] float animationFrameRate = 10f;
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
        bool isPylonOn = gameObject.GetComponentInChildren<pylonBehaviour>().getisPylonOn();
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
