using UnityEngine;

public class canvass : MonoBehaviour
{
    public GameObject baslangicCanvas; // Oyun ba�lang�c�nda a��k olan canvas objesi

    private void Update()
    {
        if (Input.touchCount > 0) // Dokunmatik ekran alg�land���nda
        {
            baslangicCanvas.SetActive(false); // Canvas'� kapat
        }
    }
}


