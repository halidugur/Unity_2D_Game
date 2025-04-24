using UnityEngine;

public class canvass : MonoBehaviour
{
    public GameObject baslangicCanvas; // Oyun baþlangýcýnda açýk olan canvas objesi

    private void Update()
    {
        if (Input.touchCount > 0) // Dokunmatik ekran algýlandýðýnda
        {
            baslangicCanvas.SetActive(false); // Canvas'ý kapat
        }
    }
}


