using System;
using UnityEngine;

public class MapTile : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 15f;
    private float deleteThresholdPodition = -40f;
    static public event Action OnMapDeleted; //�� ������ �̺�Ʈ
    
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

    //�̵�(�����ʽ� ����), ����(������ ī��Ʈ �ʽ����ʿ� ����)
}
