using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private int scorePoint = 10;

    [Header("References")]
    private Transform targetPlayer;
    private SpriteRenderer sr;
    private Collider2D col;
    private bool isDead = false;

    [SerializeField] private float attackRate = 1f; 
    
    private float attackTimer; 
    
    public int damageAmount = 10;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    public void SetTarget(Transform player)
    {
        targetPlayer = player;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime; 
        
        if (targetPlayer == null || isDead) return;
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (targetPlayer == null) return;

        Vector3 direction = (targetPlayer.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        if (direction.x > 0) sr.flipX = false;
        else if (direction.x < 0) sr.flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Bullet") || other.name.Contains("Peluru") || other.CompareTag("Bullet"))
        {
            if (!isDead)
            {
                Destroy(other.gameObject);
                StartCoroutine(DieProcess());
            }
        }
        else if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                StartCoroutine(DieProcess());
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isDead) return; 

        if (collision.gameObject.CompareTag("Player"))
        {
            if (attackTimer >= attackRate)
            {
                // Cari PlayerHealth 
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount); 
                    attackTimer = 0f; 
                }
            }
        }
    }
    private IEnumerator DieProcess()
    {
        isDead = true;
        if (col != null) col.enabled = false;

        Animator anim = GetComponent<Animator>();
        if (anim != null) anim.enabled = false;

        if (sr != null) sr.color = Color.red;

        float timer = 0;
        float duration = 0.2f;
        Vector3 startScale = transform.localScale;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, timer / duration);
            yield return null;
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(scorePoint);
        }

        Destroy(gameObject);
    }
}