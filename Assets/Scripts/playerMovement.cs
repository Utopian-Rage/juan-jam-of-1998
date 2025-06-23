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
        if (!canMove) // If the player cannot move, set movement to zero
        {
            movement = Vector2.zero;
        }
        else if (canMove) // If the player can move, get input for movement
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            playerSpeedCheck(); // Check if the player is running or walking
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
    private void EnableShock()
    {
        // Re-enable the ability to be shocked after a shock event
        canBeShocked = true;
    }
    public void ShockPlayer()
    {
        // This method is called when the player is shocked
        if (!canBeShocked) return;
        canMove = false;
        canBeShocked = false;
        playerAnimation.PlayShocked();
        Invoke(nameof(EnableMovement), 2f);
        Invoke(nameof(EnableShock), 2f);
    }
    public void MiniGameStart()
    {
        // This method is called when a mini-game starts
        // Disable player movement and animations during the mini-game
        canMove = false;
        canBeShocked = false;
        playerAnimation.PauseAnimations();
    }
    public void MiniGameEnd()
    {
        // This method is called when a mini-game ends
        // Re-enable player movement and animations after the mini-game
        canMove = true;
        canBeShocked = true;
        playerAnimation.ResumeAnimations();
    }
    private void EnableMovement()
    {
        // Re-enable player movement after a shock event
        canMove = true;
        playerAnimation.StopShocked();
    }
}