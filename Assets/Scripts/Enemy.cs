using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 8f;
    public int enemyHealthPoint = 20;
    [SerializeField] private float enemyDeleteThreshold = -30f;
    [SerializeField] private AudioClip enemyDeathSound;
    private AudioSource audioSource;
    [SerializeField] private GameObject exp;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        MoveEnemy();
        deleteOutEnemy();
    }

    protected virtual void MoveEnemy()
    {
        transform.position += Vector3.back * enemyMoveSpeed * Time.deltaTime;
    }

    protected void deleteOutEnemy()
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

    protected void CollidePlayer(Collider other)
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
            Vector3 expPositionModifiy = new Vector3(transform.position.x, 1.8f, transform.position.z);
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            enemyHealthPoint -= weapon.weaponDamage;
            if (enemyHealthPoint <= 0)
            {
                Instantiate(exp, expPositionModifiy, Quaternion.identity);
                AudioManager.instance.PlaySfx(AudioManager.Sfx.OceanEnemyDeath);
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}



