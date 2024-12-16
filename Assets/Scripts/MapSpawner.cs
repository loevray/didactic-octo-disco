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
    [SerializeField] private float moveSpeed = 15f;
   
    private float mapDeleteCount = 0;
    private Vector3 spawnPosition = new Vector3(0,0,40f);
    private float deleteThreshold = -40f;
    private Queue<GameObject> activeMaps = new Queue<GameObject>();

    //추가사항
    private bool isBossMapSpawned = false; // 보스맵 상태 관리
    public event Action OnMapSpawned; //EnemySpawner를 작동시키기 위한 액션
    [SerializeField] private float bossMapThreshold = 4; //보스맵 카운트(수정필요)
    private GameObject currentBossMap; // 현재 보스 맵 추적(0,0,0)에서 멈추기위함

    void Start()
    {
        SpawnMap(Vector3.zero); 
        SpawnMap(spawnPosition);
    }

    void Update()
    {
        MoveMaps();

        if (!isBossMapSpawned)
        {
            bool isout = CheckIsMapOut();
            if (isout)
            {
                if(mapDeleteCount > bossMapThreshold)
                {
                    BossMapSpawn();
                }
                else
                {
                    SpawnMap(spawnPosition);
                }
                DeleteMap();
            }
            
        }
    }

    void SpawnMap(Vector3 position)
    {
        GameObject selectedNewMap = mapPrefabs[UnityEngine.Random.Range(0,mapPrefabs.Length-1)]; 
        GameObject newMap = Instantiate(selectedNewMap, position, Quaternion.identity); 
        activeMaps.Enqueue(newMap);

        //EnemySpawner를 작동시키기 위한 호출
        OnMapSpawned?.Invoke();
    }

    bool CheckIsMapOut()
    {
        GameObject activeMap = activeMaps.Peek();
        if(activeMap.transform.position.z < deleteThreshold )
        {
            return true;
        }
        return false;
    }
    
    void MoveMaps()
    {
        foreach(GameObject map in activeMaps)
        {
            if (map == currentBossMap && map.transform.position.z <= 0)
            {
                continue;
            }

            map.transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
    }

    void DeleteMap()
    {
        GameObject outMap = activeMaps.Dequeue();
        Destroy(outMap);
        mapDeleteCount += 1; //맵카운트 +1
    }

    void BossMapSpawn()
    {
        if(mapDeleteCount >= bossMapThreshold)
        {
            GameObject selecteBossMap = bossMapPrefab[UnityEngine.Random.Range(0, bossMapPrefab.Length)];
            GameObject bossMapSpawn = Instantiate(selecteBossMap, spawnPosition, Quaternion.identity);
            activeMaps.Enqueue(bossMapSpawn);

            currentBossMap = bossMapSpawn;

            isBossMapSpawned = true;
        }
    }
}


