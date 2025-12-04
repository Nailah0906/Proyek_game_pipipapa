using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
    [Header("Stats Musuh")]
    public float moveSpeed = 3.0f;     
    public float shrinkSpeed = 2.0f;   
    public int scorePoint = 10;        

    [Header("Referensi")]
    public Transform targetPlayer;     

    private bool isDead = false;
    private SpriteRenderer sr;
    private Collider2D col;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    public void SetTarget(Transform player)
    {
        targetPlayer = player;
    }

    void Update()
    {
        if (targetPlayer == null || isDead) return;
        MoveToTarget();
    }

    void MoveToTarget()
    {
        // 1. Hitung arah
        Vector3 direction = (targetPlayer.position - transform.position).normalized;

        // 2. Gerak Manual
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 3. Putar badan (Atas ketemu Arah)
        transform.up = direction; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Deteksi Peluru (Apapun namanya yang penting ada kata Bullet/Peluru)
        if (other.name.Contains("Bullet") || other.name.Contains("Peluru") || other.CompareTag("Bullet"))
        {
            if (!isDead)
            {
                Destroy(other.gameObject); // Hapus Peluru
                StartCoroutine(DieProcess()); // Musuh Mati
            }
        }
    }

    IEnumerator DieProcess()
    {
        isDead = true;
        if(col != null) col.enabled = false; 
        if(sr != null) sr.color = Color.red; // Jadi merah

        // Animasi Mengecil
        while (transform.localScale.x > 0.1f)
        {
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
            yield return null;
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(scorePoint);
        }

        Destroy(gameObject); 
    }
}