using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  
    public Transform playerTarget;  
    
    [Header("Waktu Spawn")]
    public float interval = 3.0f;   
    public float radius = 8.0f;     

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || playerTarget == null) return;

        // Posisi Acak Lingkaran
        Vector2 randomPoint = Random.insideUnitCircle.normalized * radius;
        Vector3 spawnPos = playerTarget.position + (Vector3)randomPoint;

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        if (newEnemy.GetComponent<EnemyMover>())
        {
            newEnemy.GetComponent<EnemyMover>().SetTarget(playerTarget);
        }
    }
}