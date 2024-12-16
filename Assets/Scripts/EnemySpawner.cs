using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float[] enemySpawnLocationX = { -8, -4, 0, 4, 8 };
    [SerializeField] private float[] enemySpawnLocationZ = { 25, 30, 35, 40, 45, 50, 55 };

    public MapSpawner mapSpawner; // MapSpawner ÂüÁ¶

    void OnEnable()
    {
        if (mapSpawner != null)
        {
            mapSpawner.OnMapSpawned += HandleMapSpawned;
        }
    }

    void OnDisable()
    {
        if (mapSpawner != null)
        {
            mapSpawner.OnMapSpawned -= HandleMapSpawned;
        }
    }

    void HandleMapSpawned()
    {
        int enemyIndex = Random.Range(0, enemies.Length);
        int xIndex = Random.Range(0, enemySpawnLocationX.Length);
        int zIndex = Random.Range(0, enemySpawnLocationZ.Length);

        float posX = enemySpawnLocationX[xIndex];
        float posZ = enemySpawnLocationZ[zIndex];

        SpawnEnemy(posX, posZ, enemyIndex);
    }

    public void SpawnEnemy(float posX, float posZ, int index)
    {
        Vector3 spawnPos = new Vector3(posX, 1f, posZ);
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }
}
