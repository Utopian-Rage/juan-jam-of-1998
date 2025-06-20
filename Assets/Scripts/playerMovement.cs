using UnityEngine;
public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private float defaultMoveSpeed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 movement;
    private bool canMove = true;
    private bool canBeShocked = true;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        defaultMoveSpeed = moveSpeed;
    }
    void Update()
    {
        if (!canMove)
        {
            movement = Vector2.zero;
            return;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire3"))
        {
            moveSpeed *= 2;
        }
        else
        {
            moveSpeed = defaultMoveSpeed;
        }
        movement = movement.normalized;
    }
    void FixedUpdate()
    {
        Rigidbody2D.MovePosition(Rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    public void ShockPlayer()
    {
        if (!canBeShocked) return;
        canMove = false;
        canBeShocked = false;
        GetComponent<playerAnimation>()?.PlayShocked();
        Invoke(nameof(EnableMovement), 2f);
        Invoke(nameof(EnableShock), 2f); // 2s + 3s cooldown
    }
    private void EnableMovement()
    {
        canMove = true;
        GetComponent<playerAnimation>()?.StopShocked();
    }
    private void EnableShock()
    {
        canBeShocked = true;
    }
}