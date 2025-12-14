using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform playerTarget;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 1.0f;
    [SerializeField] private float spawnRadius = 10.0f;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnRandomEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnRandomEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0 || playerTarget == null) return;

        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject selectedPrefab = enemyPrefabs[randomIndex];

        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = playerTarget.position + (Vector3)randomCircle;

        GameObject newEnemy = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        if (newEnemy.TryGetComponent<EnemyMover>(out EnemyMover mover))
        {
            mover.SetTarget(playerTarget);
        }
    }
}