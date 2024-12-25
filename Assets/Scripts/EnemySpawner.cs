using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] bossEnemies;
    [SerializeField] private float[] enemySpawnLocationX = { -8, -4, 0, 4, 8 };
    [SerializeField] private float[] enemySpawnLocationZ = { 25, 30, 35, 40, 45, 50, 55 };

    public MapSpawner mapSpawner; // MapSpawner ����
    //mapSpawner�� �ִ� delete count�� ���� ��ġ�� �����ϸ� ���� ������� �ø���.(�� 10���� ������� ��+1)

    void OnEnable()
    {
        if (mapSpawner != null)
        {
            mapSpawner.OnMapSpawned += HandleMapSpawned;
            mapSpawner.OnBossMapSpawned += HandleBossMapSpawned;
        }
    }
    void OnDisable()
    {
        if (mapSpawner != null)
        {
            mapSpawner.OnMapSpawned -= HandleMapSpawned;
            mapSpawner.OnBossMapSpawned -= HandleBossMapSpawned;
        }
    }
    void HandleMapSpawned()
    {
        //�ø�������� ������ ���� ����Ʈ�� ī��Ʈ�� 1, 2�� �ɶ����� ���� �� ����
        int enemyIndex = Random.Range(0, enemies.Length);
        int xIndex = Random.Range(0, enemySpawnLocationX.Length);
        int zIndex = Random.Range(0, enemySpawnLocationZ.Length);

        float posX = enemySpawnLocationX[xIndex];
        float posZ = enemySpawnLocationZ[zIndex];

        SpawnEnemy(posX, posZ, enemyIndex);
    }
    void HandleBossMapSpawned()
    {
        int bossIndex = Random.Range(0, bossEnemies.Length); // ���� ���� ����
        SpawnBossEnemy(bossIndex);
    }
    public void SpawnEnemy(float posX, float posZ, int index)
    {
        Vector3 spawnPos = new Vector3(posX, 1f, posZ);
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }
    public void SpawnBossEnemy(int index)
    {
        Vector3 spawnPos = new Vector3(0, 1f, 51f);
        Quaternion spawnRotation = Quaternion.Euler(0, 90, 0); // Y������ 90�� ȸ��
        Instantiate(bossEnemies[index], spawnPos, spawnRotation);
    }
}
