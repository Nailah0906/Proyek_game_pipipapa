using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f; // Hancur setelah 3 detik

    private void Start()
    {
        // Hancurkan diri sendiri otomatis biar memori gak penuh
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // --- SYARAT DOSEN: GERAK MANUAL ---
        // Bergerak ke arah "Atas" relatif terhadap dirinya sendiri.
        // Karena peluru sudah diputar searah meriam saat Spawn, "Up" berarti "Maju".
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kalau nabrak musuh atau dinding, hancur.
        // (Logika musuh mati ada di script Enemy, jadi di sini cukup hancurkan peluru aja)
        if (collision.CompareTag("Enemy") || collision.name.Contains("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}