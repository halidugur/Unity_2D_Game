using UnityEngine;

public class dusman : MonoBehaviour
{
    public GameObject etkinCanvas; // Durdu�unuzda etkin olacak canvas objesi

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dusman"))
        {
            Time.timeScale = 0; // Oyunu duraklat
            etkinCanvas.SetActive(true); // Canvas'� etkinle�tir
        }
    }
}
