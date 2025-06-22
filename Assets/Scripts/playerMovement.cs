using UnityEngine;
public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeedWalk = 5f;
    [SerializeField] float moveSpeedRun = 10f;
    playerAnimation playerAnimation;
    private float defaultmoveSpeedWalk;
    private Rigidbody2D Rigidbody2D;
    private Vector2 movement;
    private bool canMove = true;
    private bool canBeShocked = true;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        defaultmoveSpeedWalk = moveSpeedWalk;
        playerAnimation = GetComponent<playerAnimation>();
        if (playerAnimation == null)
        {
            Debug.LogWarning("playerAnimation component not found!");
        }
    }
    void Update()
    {
        if (!canMove)
        {
            movement = Vector2.zero;
        }
        else if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            playerSpeedCheck();
            movement = movement.normalized;
        }
    }
    void FixedUpdate()
    {
        Rigidbody2D.MovePosition(Rigidbody2D.position + movement * moveSpeedWalk * Time.fixedDeltaTime);
    }
    void playerSpeedCheck()
    {
        if (Input.GetButton("Fire3"))
        {
            moveSpeedWalk = moveSpeedRun;
        }
        else
        {
            moveSpeedWalk = defaultmoveSpeedWalk;
        }
    }
    public void ShockPlayer()
    {
        if (!canBeShocked) return;
        canMove = false;
        canBeShocked = false;
        playerAnimation.PlayShocked();
        Invoke(nameof(EnableMovement), 2f);
        Invoke(nameof(EnableShock), 2f);
    }
    public void MiniGameStart()
    {
        canMove = false;
        canBeShocked = false;
        playerAnimation.PauseAnimations();
    }
    public void MiniGameEnd()
    {
        canMove = true;
        canBeShocked = true;
        playerAnimation.ResumeAnimations();
    }
    private void EnableMovement()
    {
        canMove = true;
        playerAnimation.StopShocked();
    }
    private void EnableShock()
    {
        canBeShocked = true;
    }
}