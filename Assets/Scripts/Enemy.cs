using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed = 15f;
    [SerializeField] private int enemyHealthPoint = 1;
    [SerializeField] private float enemyDeleteThreshold = -30f;
    [SerializeField] private GameObject exp;
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
        CollidWithWeapon(other);

        CollidWithPlayer(other);

    }
    void CollidWithWeapon(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            enemyHealthPoint -= weapon.weaponDamage;
            if (enemyHealthPoint <= 0)
            {
                Debug.Log("�� ü�� 0��");
                Vector3 expPosition = new Vector3(transform.position.x, 1.6f, transform.position.z);
                Instantiate(exp, expPosition, Quaternion.identity);
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
    void CollidWithPlayer(Collider other)
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
}


