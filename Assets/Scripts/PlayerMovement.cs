using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Kecepatan Lari Player")]
    [SerializeField] private float speed;
    [Header("Kekuatan Dash Player")]
    [SerializeField] private float dash;


    private Rigidbody2D body;
    private Animator anim;
    private bool Grounded;
    private float HorizontalMovement;

    [Header("Ukuran Player yang ditampilkan")]
    public float playerSizeX = 7;
    public float playerSizeY = 7;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalMovement * speed, body.velocity.y);

        //Flip player when facing left/right.
        if (HorizontalMovement > 0.01f)
            transform.localScale = new Vector3(playerSizeX, playerSizeY, 1);
        else if (HorizontalMovement < -0.01f)
            transform.localScale = new Vector3(-playerSizeX, playerSizeY, 1);

        // Lompat
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        // Nge-Dash
        if (Input.GetKey(KeyCode.LeftShift))
        {
            body.velocity = new Vector2(HorizontalMovement * dash, body.velocity.y);
        }

        //sets animation parameters
        anim.SetBool("Walk", HorizontalMovement != 0);
        anim.SetBool("Grounded", Grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("Jump");
        Grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Grounded = true;
    }

}