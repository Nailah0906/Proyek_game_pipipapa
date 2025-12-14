using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Ini biar dia dikenal semua orang
    public int totalScore = 0;

    [Header("UI Text References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI finalScoreText;

    [Header("Panel References")]
    public GameObject gameOverPanel;

    void Awake()
    {
        // Singleton Pattern (Jurus biar Manager cuma ada 1)
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
        // --- PENAMBAHAN: Sembunyikan Game Over Panel di awal ---
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        
        // Panggil Update Score UI saat game mulai
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        Debug.Log("Skor Musuh Mati: " + totalScore);

        UpdateScoreUI();
    }

    // Contoh dalam script peluru/musuh, saat musuh hancur:

    public void OnEnemyDestroyed(int points)
    {
        // Cari ScoreManager di scene dan panggil AddScore
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
            gameOverPanel.SetActive(true); // Tampilkan Panel Game Over
        }
        
        if (finalScoreText != null)
        {
            finalScoreText.text = "SKOR AKHIR ANDA: " + totalScore;
        }
        
    }

    public void RestartGame()
    {
        // Pastikan waktu game kembali normal
        Time.timeScale = 1f; 
        
        // Muat ulang scene yang aktif saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Destroy(gameObject); 
    }
}