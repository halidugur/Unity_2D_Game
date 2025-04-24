using UnityEngine;

public class dusman1 : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket h�z�
    public Transform leftWall; // Sol duvar nesnesi
    public Transform rightWall; // Sa� duvar nesnesi

    private int moveDirection = 1; // Hareket y�n� (1 sa�a, -1 sola)
    private bool changingDirection = false; // Y�n de�i�imi s�ras�nda kontrol

    private void Update()
    {
        // Hareketi g�ncelle
        if (!changingDirection)
        {
            transform.Translate(Vector2.right * moveSpeed * moveDirection * Time.deltaTime);

            // E�er duvarlardan birine ula��ld�ysa y�n� de�i�tir
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
        Invoke("FinishDirectionChange", 0.1f); // Y�n de�i�imini tamamlama fonksiyonunu gecikmeli �a��r
        FlipSprite(); // G�rsel y�n�n� de�i�tir
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

    // �arp��ma kontrol�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Duvar"))
        {
            ChangeDirection(); // Duvara �arp�nca y�n� de�i�tir
        }
    }
}
