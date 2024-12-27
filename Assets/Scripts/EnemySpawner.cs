using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] bossEnemies;
    [SerializeField] private float[] enemySpawnLocationX = { -8, -4, 0, 4, 8 };
    [SerializeField] private float[] enemySpawnLocationZ = { 25, 30, 35, 40, 45, 50, 55 };
    [SerializeField] private float enemyIncreaseThreshold = 8;

    public MapSpawner mapSpawner;
    private readonly int enemiesPerStage = 3;
    private readonly int bossEnemiesPerStage = 1;
    private int enemyHealthIncrement = 1; //스폰마다 증가할 적의 체력
    private float additionalEnemies = 0; // 추가로 생성할 적의 수 변수

    void OnEnable()
    {
        if (mapSpawner != null)
        {
            mapSpawner.OnMapSpawned += HandleMapSpawned;
            mapSpawner.OnBossMapSpawned += HandleBossMapSpawned;
        }
        MapTile.OnMapDeleted += HandleMapDeleted;
    }
    void OnDisable()
    {
        if (mapSpawner != null)
        {
            mapSpawner.OnMapSpawned -= HandleMapSpawned;
            mapSpawner.OnBossMapSpawned -= HandleBossMapSpawned;
        }
        MapTile.OnMapDeleted -= HandleMapDeleted;
    }
    

    void HandleMapSpawned()
    {
        GameManager gameManager = GameManager.Instance;
        int minIndex = (gameManager.CurrentStage - 1) * enemiesPerStage;
        int maxIndex = (gameManager.CurrentStage) * enemiesPerStage;

        for (int i = 0; i < 1 + additionalEnemies; i++) 
        {
            int enemyIndex = Random.Range(minIndex, maxIndex);
            int xIndex = Random.Range(0, enemySpawnLocationX.Length);
            int zIndex = Random.Range(0, enemySpawnLocationZ.Length);

            float posX = enemySpawnLocationX[xIndex];
            float posZ = enemySpawnLocationZ[zIndex];

            SpawnEnemy(posX, posZ, enemyIndex);
        }
    }

    void HandleBossMapSpawned()
    {
        GameManager gameManager = GameManager.Instance;
        int minIndex = (gameManager.CurrentStage - 1) * bossEnemiesPerStage;
        int maxIndex = gameManager.CurrentStage * bossEnemiesPerStage;

        int bossIndex = Random.Range(minIndex, maxIndex);
        SpawnBossEnemy(bossIndex);
    }

    void HandleMapDeleted()
    {
        float mapDeleteCount = mapSpawner.mapDeleteCount;
        additionalEnemies = mapDeleteCount / enemyIncreaseThreshold;
    }


    public void SpawnEnemy(float posX, float posZ, int index)
    {
        
        GameObject enemyPrefab = enemies[index];
        Vector3 spawnPos = new Vector3(posX, enemyPrefab.transform.position.y, posZ);
        GameObject enemyInstance = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        IncreaseEnemyHealth(enemyInstance);
    }

    private void IncreaseEnemyHealth(GameObject enemyInstance)
    {
        Enemy enemyScript = enemyInstance.GetComponent<Enemy>();
        enemyScript.enemyHealthPoint += enemyHealthIncrement;
        enemyHealthIncrement += 1;
    }

    public void SpawnBossEnemy(int index)
    {
        GameObject bossPrefab = bossEnemies[index];
        Vector3 spawnPos = new Vector3(0, bossPrefab.transform.position.y, 51f);
        Quaternion spawnRotation = Quaternion.Euler(0, 90, 0);
        Instantiate(bossPrefab, spawnPos, spawnRotation);
    }
}
