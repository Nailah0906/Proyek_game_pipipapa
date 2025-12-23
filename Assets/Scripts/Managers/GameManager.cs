using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public int totalScore = 0;

    [Header("UI Text References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI finalScoreText;

    [Header("Panel References")]
    public GameObject gameOverPanel;

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        Debug.Log("Skor Musuh Mati: " + totalScore);

        UpdateScoreUI();
    }

    public void OnEnemyDestroyed(int points)
    {
        FindObjectOfType<ScoreManager>().AddScore(points);
        Destroy(gameObject);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore;
        }
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth + "/" + maxHealth;
        }
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
        
        if (finalScoreText != null)
        {
            finalScoreText.text = "SKOR AKHIR ANDA: " + totalScore;
        }
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Destroy(gameObject); 
    }
}