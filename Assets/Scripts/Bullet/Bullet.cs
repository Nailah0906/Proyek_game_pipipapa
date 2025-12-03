using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Kecepatan Peluru
    public float speed = 15f;
    private Rigidbody2D rb;

    void Start()
    {
        // Ambil komponen Rigidbody2D saat Peluru dibuat
        rb = GetComponent<Rigidbody2D>();

        // Berikan kecepatan awal ke atas
        // transform.up adalah arah Y positif untuk objek 2D
        rb.linearVelocity = transform.up * speed;
    }

    void Update()
    {
        // Hancurkan peluru jika sudah melewati batas atas layar (agar tidak menumpuk)
        if (transform.position.y > 8f)
        {
            Destroy(gameObject);
        }
    }
}