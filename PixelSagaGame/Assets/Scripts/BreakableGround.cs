using UnityEngine;

public class BreakableGround : MonoBehaviour
{
    public float timeToBreak = 5f; // Zeminin kaybolması için gereken süre
    private bool isPlayerOnGround = false;
    private SpriteRenderer spriteRenderer;
    private float startTime;
    private bool isBroken = false; // Eğer kırıldıysa true olur

    public float respawnDelay = 2f; // Yeniden oluşturma gecikmesi
    private Vector3 initialPosition; // Başlangıç pozisyonunu sakla

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startTime = Time.time;
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isPlayerOnGround && !isBroken)
        {
            float elapsedTime = Time.time - startTime;

            // Renk değerini zamanla azaltarak zeminin kaybolma efektini oluştur
            float t = elapsedTime / timeToBreak;
            Color newColor = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, t));
            spriteRenderer.color = newColor;

            // Belirli süre dolunca zemini yok et
            if (elapsedTime >= timeToBreak)
            {
                BreakGround();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnGround = true;
            startTime = Time.time; // Sayaç başlama zamanını kaydet
        }
    }

    private void BreakGround()
    {
        isBroken = true;

        // Nesneyi devre dışı bırak
        gameObject.SetActive(false);

        // Belirli bir süre sonra geri çağır
        Invoke("RespawnGround", respawnDelay);
    }

    private void RespawnGround()
    {
        // Nesneyi başlangıç pozisyonuna geri taşı ve tekrar etkinleştir
        transform.position = initialPosition;
        spriteRenderer.color = Color.white; // Renk sıfırla
        isBroken = false; // Durumu sıfırla
        isPlayerOnGround = false; // Durumu sıfırla
        gameObject.SetActive(true);
    }
}
