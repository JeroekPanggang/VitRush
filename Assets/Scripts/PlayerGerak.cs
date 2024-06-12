using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGerak : MonoBehaviour
{    
    public static PlayerGerak Player;
    // Size Player In Game
    [Header("Ukuran Player yang ditampilkan")]
    public float playerSizeX = 7;
    public float playerSizeY = 7;
    
    
    // Walk Speed and Dash Distance
    [Header("Movement Stat")]
    [SerializeField] private float Speed;
    [SerializeField] private float dashPower;
    [SerializeField] private float jumpPower;


    // Layer Mask
    [Header("Layer Mask")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    // 2D Component
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxColl;


    private float wallJumpCooldown;
    //private bool Grounded;
    private float Move;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxColl = GetComponent<BoxCollider2D>();

        Player = this;
    }


    private void Update()
    {
        Move = Input.GetAxis("Horizontal");
        //body.velocity = new Vector2(Move * Speed, body.velocity.y);

        //Flip Player Sprite when moving right or left
        if (Move > 0.01f)
            transform.localScale = new Vector3(playerSizeX, playerSizeY, 1);
        else if (Move < -0.01f)
            transform.localScale = new Vector3(-playerSizeX, playerSizeY, 1);

        // Lompat
/*        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            Jump();
        }*/

        // Nge-Dash
        

        //Set animator parameters
        anim.SetBool("Walk", Move != 0);
        //anim.SetBool("Grounded", Grounded);
        anim.SetBool("Grounded", isGrounded());

        if (wallJumpCooldown > 0.2f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                
                body.velocity = new Vector2(Move * dashPower, body.velocity.y);
            }
            else
            {
                
                body.velocity = new Vector2(Move * Speed, body.velocity.y);
            }
            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 2.5f;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    /*    private void Jump()
        {
            if (isGrounded())
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower);
                anim.SetTrigger("Jump");
            }

            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
            Grounded = false;

        }*/


    // Loncat
    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (Move == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
        }
    }

    // Ngecek Tanah --> Mencegah Infinite Jump
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }


    // Ngecek Dinding --> Sejauh ini gak ke pake
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    // Teleport Player Jika Jatuh Ke Lobang
    public void TeleportIdiotWhoFall(float teleportX, float teleportY)
    {
        transform.position = new Vector3 (teleportX, teleportY, 1);
        
        Debug.Log("Jatuh");
    }

    public void UnlockDash()
    {
        dashPower = 15;
    }

    public void NoMovement()
    {
        Speed = 0;
        jumpPower = 0;
        dashPower = 0;
    }
}
