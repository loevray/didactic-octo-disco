using System;
using UnityEngine;

public class MapTile : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 15f;
    private float deleteThresholdPodition = -40f;
    static public event Action OnMapDeleted; //맵 삭제시 이벤트
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveMapTile();
        DeleteMap();
    }

    void MoveMapTile()
    {
        if (gameObject.tag == "BossMap" && transform.position.z <= 0)
        {
            return;
        }
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;
    }

    void DeleteMap()
    {
        if (transform.position.z < deleteThresholdPodition)
        {
            Destroy(gameObject);
            OnMapDeleted?.Invoke();
        }
    }

    //이동(보스맵시 멈춤), 삭제(삭제된 카운트 맵스포너에 전달)
}
