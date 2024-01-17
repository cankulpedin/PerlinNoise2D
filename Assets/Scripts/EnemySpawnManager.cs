using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemy;

    [SerializeField] private int maxEnemyCount = 5;
    private int currentEnemyCount = 0;

    private float spawnOffset = 8.0f;

    private void Update()
    {
        while(currentEnemyCount < maxEnemyCount)
        {
            SpawnEnemy();
            currentEnemyCount++;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPos = RandomPointOnCircleEdge();
        Instantiate(enemy, spawnPos, Quaternion.identity);
    }

    private Vector3 RandomPointOnCircleEdge()
    {
        float currentX = transform.position.x;
        float currentY = transform.position.y;

        Vector2 vector2 = new Vector2(currentX,currentY) +  Random.insideUnitCircle.normalized * spawnOffset;
        return new Vector3(vector2.x, vector2.y, -1);
    }
}
