using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float shrinkSpeed = 5.0f;
    [SerializeField] private int scorePoint = 10;

    [Header("References")]
    private Transform targetPlayer;
    private SpriteRenderer sr;
    private Collider2D col;
    private EnemyAnimator anim;

    private bool isDead = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<EnemyAnimator>();
    }

    public void SetTarget(Transform player)
    {
        targetPlayer = player;
    }

    private void Update()
    {
        if (targetPlayer == null || isDead) return;
        MoveToTarget();
    }

    private void MoveToTarget()
    {
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
    }

    private IEnumerator DieProcess()
    {
        isDead = true;
        if (col != null) col.enabled = false;
        if (anim != null) anim.enabled = false;

        if (sr != null) sr.color = Color.red;

        while (transform.localScale.x > 0.05f)
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