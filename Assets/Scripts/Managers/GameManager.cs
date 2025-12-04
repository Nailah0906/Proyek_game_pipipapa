using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Ini biar dia dikenal semua orang
    public int totalScore = 0;

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

    public void AddScore(int amount)
    {
        totalScore += amount;
        Debug.Log("Skor Musuh Mati: " + totalScore);
    }
}