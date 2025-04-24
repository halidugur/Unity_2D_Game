using UnityEngine;

public class karakter : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public LayerMask groundLayer;

    private bool isJumping = false;
    private bool canJump = true;
    private Rigidbody2D rb;

    private bool isTouchingRight = false;
    private bool isTouchingLeft = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isTouchingRight = false;
        isTouchingLeft = false;

        // Dokunmatik ekran kontrolü
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                // Ekranýn sað yarýsý
                if (touch.position.x > Screen.width / 2)
                {
                    // Saða dokunma
                    if (touch.position.x > Screen.width * 0.75f)
                    {
                        isTouchingRight = true;
                        isTouchingLeft = false;
                    }
                    // Sola dokunma
                    else if (touch.position.x < Screen.width * 0.75f)
                    {
                        isTouchingLeft = true;
                        isTouchingRight = false;
                    }
                }
                // Ekranýn sol yarýsý
                else
                {
                    // Tek dokunma ile zýplama
                    if (touch.phase == TouchPhase.Began && canJump)
                    {
                        Jump();
                    }
                }
            }
        }
        else
        {
            isTouchingRight = false;
            isTouchingLeft = false;
        }
    }

    void FixedUpdate()
    {
        // Hareket kontrolü
        if (isTouchingRight)
        {
            MoveRight();
        }
        else if (isTouchingLeft)
        {
            MoveLeft();
        }
        else
        {
            StopMoving();
        }

        // Zýplama kontrolü
        if (isJumping && rb.velocity.y == 0)
        {
            isJumping = false;
            canJump = true;
        }
    }

    void Jump()
    {
        if (canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
            isJumping = true;
        }
    }

    void MoveRight()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
