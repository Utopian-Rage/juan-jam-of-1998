using System.Runtime.CompilerServices;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private float defaultMoveSpeed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 movement;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
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
        
        Debug.Log($"Movement: {movement}, Speed: {moveSpeed}");
    }

    void FixedUpdate()
    {
        Rigidbody2D.MovePosition(Rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}