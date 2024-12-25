using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed = 15f;
    [SerializeField] private int enemyHealthPoint = 1;
    [SerializeField] private float enemyDeleteThreshold = -30f;

    //public event Action<int> enemyHpChange;  
    //public event Action enemyDead;    

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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("������ �浹 �̺�Ʈ �߻�");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("������ �÷��̾�� �浹 �̺�Ʈ �߻�");
            Player player = other.gameObject.GetComponent<Player>();
            Debug.Log(enemyHealthPoint);
            player.TakeDamage(enemyHealthPoint);
            
            Destroy(gameObject);
        }
    }

    //����� �浹 �� ü�±�� 0���ϰ��Ǹ� ����ġ���� ���� �� �ı�
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Weapon")
    //    {
    //        Weapon weapon = other.gameObject.GetComponent<Weapon>();
    //        enemyHealthPoint -= weapon.damage;
    //        if (enemyHealthPoint < 0)
    //        {
    //            Instantiate(Exp, transform.position, Quaternion.identity);
    //            Destroy(gameObject);
    //        }
    //    }
    //}

}


