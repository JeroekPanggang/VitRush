using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGerak : MonoBehaviour
{    
    
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
    //[SerializeField] private LayerMask groundLayer;

    // 2D Component
    private Rigidbody2D body;
    private Animator anim;
    //private BoxCollider2D boxColl;
 
    
    private bool Grounded;
    private float Move;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //boxColl = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        Move = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Move * Speed, body.velocity.y);

        

        //Flip Player Sprite when moving right or left
        if (Move > 0.01f)
            transform.localScale = new Vector3(playerSizeX, playerSizeY, 1);
        else if (Move < -0.01f)
            transform.localScale = new Vector3(-playerSizeX, playerSizeY, 1);

        // Lompat
        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            Jump();
        }

        // Nge-Dash
        if (Input.GetKey(KeyCode.LeftShift))
        {

            body.velocity = new Vector2(Move * dashPower, body.velocity.y);
        }

        //Set animator parameters
        anim.SetBool("Walk", Move != 0);
        anim.SetBool("Grounded", Grounded);
    }

    private void Jump()
    {
        /*        if (isGrounded())
                {
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                    anim.SetTrigger("Jump");
                }*/

        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("Jump");
        Grounded = false;

    }

    /*    private bool isGrounded()
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
            return raycastHit.collider != null;
        }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Grounded = true;
    }

}
