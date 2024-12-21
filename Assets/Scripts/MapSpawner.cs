using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class MapSpawner : MonoBehaviour
{
    //스테이지는 게임매니저에서 관리 
    
    [SerializeField] private GameObject[] mapPrefabs;
    [SerializeField] private GameObject[] bossMapPrefab;
   
    public float mapDeleteCount = 0f; //EnemySpawner에서 사용하기 위해 public으로 교체
    private Vector3 spawnPosition = new Vector3(0,0,40f);

    //추가사항
    private bool isBossMapSpawned = false; // 보스맵 상태 관리
    public event Action OnMapSpawned; //EnemySpawner를 작동시키기 위한 액션
    public event Action OnBossMapSpawned;
    [SerializeField] private float bossMapThreshold = 4f; //보스맵 카운트(수정필요)

    void Start()
    {
        MapTile.OnMapDeleted += HandleMapDeleted;
        SpawnMap(Vector3.zero); 
        SpawnMap(spawnPosition);
    }

    void Update() 
    { 
        //온 맵 딜리티드가 더해지면 => 맵 생성, x이상 더해지면 대신 보스맵생성
        
    }

    void HandleMapDeleted()
    {
        mapDeleteCount++;
        if (isBossMapSpawned)
        {
            return;
        }

        if (mapDeleteCount > bossMapThreshold)
        {
            BossMapSpawn();
        }
        else
        {
            SpawnMap(spawnPosition);
        }
    }

    void SpawnMap(Vector3 position)
    {
        GameObject selectedNewMap = mapPrefabs[UnityEngine.Random.Range(0,mapPrefabs.Length-1)]; 
        GameObject newMap = Instantiate(selectedNewMap, position, Quaternion.identity);
        
        OnMapSpawned?.Invoke();//EnemySpawner를 작동시키기 위한 호출
    }

    void BossMapSpawn()
    {
        
        GameObject selecteBossMap = bossMapPrefab[UnityEngine.Random.Range(0, bossMapPrefab.Length)];
        GameObject bossMapSpawn = Instantiate(selecteBossMap, spawnPosition, Quaternion.identity);

        OnBossMapSpawned?.Invoke();
        isBossMapSpawned = true;
        
    }
}


