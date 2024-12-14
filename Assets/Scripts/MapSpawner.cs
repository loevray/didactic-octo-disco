using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    //스테이지는 게임매니저에서 관리 
    
    [SerializeField]
    private GameObject[] mapPrefabs;
    
    [SerializeField]
    private GameObject[] bossMapPrefab;

    [SerializeField]
    private float moveSpeed = 15f;

    private float MapDeleteCount = 0;

    private Vector3 spawnPosition = new Vector3(0,0,40f);

    private float deleteThreshold = -40f;


    private Queue<GameObject> activeMaps = new Queue<GameObject>();

    void Start()
    {
        SpawnMap(Vector3.zero); 
        SpawnMap(spawnPosition);
    }

    void Update()
    {
        MoveMaps();
        bool isout = CheakIsMapOut();
        if(isout){
            SpawnMap(spawnPosition);
            DeleteMap();
        }
        
    
    }
    void SpawnMap(Vector3 position)
    {
        GameObject selectedNewMap = mapPrefabs[Random.Range(0,mapPrefabs.Length-1)]; 
        GameObject newMap = Instantiate(selectedNewMap, position, Quaternion.identity); 
        activeMaps.Enqueue(newMap);
    }
    bool CheakIsMapOut()
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
            map.transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
    }

    void DeleteMap()
    {
        GameObject outMap = activeMaps.Dequeue();
        Destroy(outMap);
    }

}


