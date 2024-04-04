using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Kecepatan Lari Player")]
    [SerializeField] private float speed;
    [Header("Kekuatan Dash Player")]
    [SerializeField] private float dash;
    private Rigidbody2D body;

    [Header("Ukuran Player yang ditampilkan")]
    public float playerSizeX = 7;
    public float playerSizeY = 7;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalMovement * speed, body.velocity.y);

        //Flip player when facing left/right.
        if (HorizontalMovement > 0.01f)
            transform.localScale = new Vector3(playerSizeX, playerSizeY, 1);
        else if (HorizontalMovement < -0.01f)
            transform.localScale = new Vector3(-playerSizeX, playerSizeY, 1);

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            body.velocity = new Vector2 (HorizontalMovement * dash, body.velocity.y);
        }
    }
}