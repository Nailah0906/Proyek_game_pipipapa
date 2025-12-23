using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int currentScore = 0;

    public static ScoreManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        currentScore = 0;
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        if (points > 0)
        {
            currentScore += points;
            Debug.Log("Score Ditambahkan: " + points + ". Skor Total: " + currentScore);
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
        else
        {
            Debug.LogError("ScoreText (TextMeshProUGUI) belum dihubungkan di Inspector!");
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreText();
    }
}