using UnityEngine;

public class dusman1 : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    public Transform leftWall; // Sol duvar nesnesi
    public Transform rightWall; // Sað duvar nesnesi

    private int moveDirection = 1; // Hareket yönü (1 saða, -1 sola)
    private bool changingDirection = false; // Yön deðiþimi sýrasýnda kontrol

    private void Update()
    {
        // Hareketi güncelle
        if (!changingDirection)
        {
            transform.Translate(Vector2.right * moveSpeed * moveDirection * Time.deltaTime);

            // Eðer duvarlardan birine ulaþýldýysa yönü deðiþtir
            if ((moveDirection == 1 && transform.position.x >= rightWall.position.x) ||
                (moveDirection == -1 && transform.position.x <= leftWall.position.x))
            {
                ChangeDirection();
            }
        }
    }

    private void ChangeDirection()
    {
        moveDirection *= -1;
        changingDirection = true;
        Invoke("FinishDirectionChange", 0.1f); // Yön deðiþimini tamamlama fonksiyonunu gecikmeli çaðýr
        FlipSprite(); // Görsel yönünü deðiþtir
    }

    private void FinishDirectionChange()
    {
        changingDirection = false;
    }

    private void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Çarpýþma kontrolü
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Duvar"))
        {
            ChangeDirection(); // Duvara çarpýnca yönü deðiþtir
        }
    }
}
