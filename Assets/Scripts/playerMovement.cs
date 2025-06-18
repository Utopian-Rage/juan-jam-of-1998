using UnityEngine;
public class playerMovement : MonoBehaviour
{
    // Player movement speed
    [SerializeField] float moveSpeed = 5f;
    // Components and other variables
    private float defaultMoveSpeed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMoveSpeed = moveSpeed;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire3"))
        {
            moveSpeed *= 2;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            moveSpeed = defaultMoveSpeed;
        }
        movement = movement.normalized;
    }
    void FixedUpdate()
    {
        Rigidbody2D.MovePosition(Rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}