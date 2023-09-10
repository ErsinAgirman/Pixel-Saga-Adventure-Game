using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private float toggleInterval = 3f; // Süreyi ayarlayabileceğiniz bir değişken

    private bool isActive = true; // Başlangıçta aktif durumda

    private void Start()
    {
        // Belirli aralıklarla TrapToggle fonksiyonunu çağırır
        InvokeRepeating("TrapToggle", 0f, toggleInterval);
    }

    private void TrapToggle()
    {
        isActive = !isActive; // Durumu tersine çevirir (aktif ise inaktif yapar, inaktif ise aktif yapar)
        gameObject.SetActive(isActive); // Objeyi duruma göre aktif veya inaktif yapar
    }
}
