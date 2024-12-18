using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed = 15f;
    [SerializeField] private int enemyHealthPoint = 10;
    [SerializeField] private float enemyDeleteThreshold = -30f;

    public event Action<int> enemyHpChange;  // HP 변경 이벤트
    public event Action enemyDead;     // 적 사망 이벤트
    static public event Action ExpDrop; //맵 삭제시 이벤트



    private void Start()
    {
        

    }
    void Update()
    {
        MoveEnemy();
        deleteOutEnemy();
    }

    void MoveEnemy()
    {
        transform.position += Vector3.back * enemyMoveSpeed * Time.deltaTime;
    }

    void deleteOutEnemy()
    {
        if (transform.position.z < enemyDeleteThreshold)
        {
            Destroy(gameObject);
        }
    }

    //무기와 충돌 시 체력깍고 0이하가되면 경험치오브 생성 및 파괴
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            enemyHealthPoint -= weapon.damage;
            if (enemyHealthPoint < 0)
            {
                ExpDrop?.Invoke();
                Destroy(gameObject);
            }
        }
    }





}


