using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public Text healthText;
    public GameObject gameOverUI; 

    private int currentHealth;
    private bool canTakeDamage = true;

    void Start()
    {

        Time.timeScale = 1;

        currentHealth = maxHealth;
        UpdateHealthUI();

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (!canTakeDamage) return;

        currentHealth -= damageAmount;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            PlayerDie();
        }
        else
        {
            canTakeDamage = false;
            Invoke("ResetDamageCooldown", 0.5f);
        }
    }

    void PlayerDie()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        Time.timeScale = 0;
    }

    void ResetDamageCooldown()
    {
        canTakeDamage = true;
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}