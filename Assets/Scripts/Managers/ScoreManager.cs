using UnityEngine;
using TMPro; // Pastikan ini ada untuk TextMeshPro!

public class ScoreManager : MonoBehaviour
{
    // Variabel publik agar bisa dihubungkan di Inspector
    public TextMeshProUGUI scoreText;

    // Variabel privat untuk menyimpan nilai skor
    private int currentScore = 0;

    // Instance statis untuk memudahkan akses dari script lain
    public static ScoreManager Instance { get; private set; }

    void Awake()
    {
        // Implementasi Singleton dasar (memastikan hanya ada satu ScoreManager)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            // Jika ini GameManager, mungkin Anda ingin menambahkan DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Pastikan skor awal (biasanya 0) ditampilkan
        currentScore = 0;
        UpdateScoreText();
    }

    /// <summary>
    /// Fungsi utama untuk menambahkan skor
    /// </summary>
    /// <param name="points">Jumlah poin yang akan ditambahkan.</param>
    public void AddScore(int points)
    {
        if (points > 0)
        {
            currentScore += points;
            Debug.Log("Score Ditambahkan: " + points + ". Skor Total: " + currentScore);
            UpdateScoreText();
        }
    }

    /// <summary>
    /// Memperbarui tampilan teks UI
    /// </summary>
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            // Menampilkan format teks "Score: [Nilai Skor]"
            scoreText.text = "Score: " + currentScore.ToString();
        }
        else
        {
            Debug.LogError("ScoreText (TextMeshProUGUI) belum dihubungkan di Inspector!");
        }
    }

    // Fungsi tambahan jika Anda ingin mereset skor
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreText();
    }
}