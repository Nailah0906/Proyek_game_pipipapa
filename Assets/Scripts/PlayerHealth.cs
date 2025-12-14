using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private bool isInvincible = false;
    [SerializeField] private float invincibilityDuration = 1f;
    void Start()
    {
        currentHealth = maxHealth;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.UpdateHealthUI(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.UpdateHealthUI(currentHealth, maxHealth);
        }
        StartCoroutine(InvincibilityCoroutine());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        // Opsional: Tambahkan efek visual berkedip di sini
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}