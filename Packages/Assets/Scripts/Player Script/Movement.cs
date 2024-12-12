using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Size Player In Game
    [Header("Ukuran Player yang ditampilkan")]
    public float playerSizeX = 7;
    public float playerSizeY = 7;


    // Walk Speed and Dash Distance
    [Header("Movement Stat")]
    [SerializeField] private float Speed;
    [SerializeField] private float jumpPower;

    // Layer Mask
    [Header("Layer Mask")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    // 2D Component
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxColl;
    private float Move;

    public static Movement Player;

    // Dash Component
   [SerializeField] private float dashPower;
    public float dashTime = 0.2f;       // Duration of the dash
    public float dashCooldown = 1f;     // Cooldown time between dashes
    private float dashTimeLeft;
    private float lastDash = -100f;     // To track time since last dash
    private Vector2 dashDirection;


    private float wallJumpCooldown;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxColl = GetComponent<BoxCollider2D>();

        Player = this;
    }

    private void Update()
    {
        

        //Flip Player Sprite when moving right or left
        if (Move > 0.01f)
            transform.localScale = new Vector3(playerSizeX, playerSizeY, 1);
        else if (Move < -0.01f)
            transform.localScale = new Vector3(-playerSizeX, playerSizeY, 1);

        //Set animator parameters
        anim.SetBool("Walk", Move != 0);
        anim.SetBool("Grounded", isGrounded());

        if (Input.GetKey(KeyCode.Space)) Jump();

        // Get dash input (assuming left shift is used to dash)
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= lastDash + dashCooldown)
        {
            // Start dashing
            dashTimeLeft = dashTime;
            lastDash = Time.time;
            dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            //Debug.Log("Weeee");
        }


    }

    private void FixedUpdate()
    {
        // If player is in dash state
        if (dashTimeLeft > 0)
        {
            //Debug.Log(dashDirection);
            body.velocity = dashDirection * dashPower;
            dashTimeLeft -= Time.fixedDeltaTime;
        }
        else
        {
            Move = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(Move * Speed, body.velocity.y);
            // If not dashing, regular movement can be handled here
            // rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
        }
    }

    // Jump Function
    private void Jump() 
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
        }

    }
    
    // Check Ground --> Preventing Infinite Jump
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
        
    }


    // Code used by Void to teleport Player
    public void TeleportIdiotWhoFall(float teleportX, float teleportY)
    {
        transform.position = new Vector3(teleportX, teleportY, 1);

        Debug.Log("Jatuh");
    }

 
    public void NoMovement()
    {
        Speed = 0;
        jumpPower = 0;
        dashPower = 0;
    }
}
