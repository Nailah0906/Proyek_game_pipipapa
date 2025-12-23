using UnityEngine;

public class Bullet : MonoBehaviour
{
    // kecepatan Peluru
    public float speed = 15f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = transform.up * speed;
    }

    void Update()
    {
        if (transform.position.y > 8f)
        {
            Destroy(gameObject);
        }
    }
}