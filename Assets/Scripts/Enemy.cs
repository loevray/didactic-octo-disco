using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed = 15f;
    [SerializeField] private int enemyHealthPoint = 1;
    [SerializeField] private float enemyDeleteThreshold = -30f;
    [SerializeField] private GameObject exp;

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
        CollideWeapon(other);
        CollidePlayer(other);
    }

    private void CollidePlayer(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            Debug.Log(enemyHealthPoint);
            player.TakeDamage(enemyHealthPoint);

            Destroy(gameObject);
        }
    }

    private void CollideWeapon(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Vector3 expPositionModifiy = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            enemyHealthPoint -= weapon.weaponDamage;
            if (enemyHealthPoint < 0)
            {
                Instantiate(exp, expPositionModifiy, Quaternion.identity);
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}



