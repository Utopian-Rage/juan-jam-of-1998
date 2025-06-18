using UnityEngine;
public class playerAnimation : MonoBehaviour
{
    [SerializeField] Sprite backSprite0,backSprite1,backSprite2;
    [SerializeField] Sprite frontSprite0,frontSprite1,frontSprite2;
    [SerializeField] Sprite sideSprite0,sideSprite1,sideSprite2;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        spriteRenderer.sprite = frontSprite0;
        spriteRenderer.flipX = false;
        if (vertical > 0)
        {
            spriteRenderer.sprite = backSprite0;
            spriteRenderer.flipX = false;
        }
        if (horizontal < 0)
        {
            spriteRenderer.sprite = sideSprite0;
            spriteRenderer.flipX = false;
        }
        if (horizontal > 0)
        {
            spriteRenderer.sprite = sideSprite0;
            spriteRenderer.flipX = true;
        }
    }
}
