using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float BossEnemyMoveSpeed = 15f;
    [SerializeField] private int bossEnemyHealthPoint = 100;

    private bool isBossStoped = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBossEnemy();
    }

    void MoveBossEnemy()
    {
        if (gameObject.tag == "BossEnemy" && transform.position.z <= 11)
        {
            if (!isBossStoped)
            {
                isBossStoped = true;
            }
            return;
        }
        transform.position += Vector3.back * BossEnemyMoveSpeed * Time.deltaTime;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Weapon")
    //    {
    //        Weapon weapon = other.gameObject.GetComponent<Weapon>();
    //        enemyHealthPoint -= weapon.damage;
    //        if (enemyHealthPoint < 0)
    //        {
    //            Instantiate(Exp, transform.position, Quaternion.identity); //추후에 더 큰 경험치, 보상등으로 교체
    //            Destroy(gameObject);
    //        }
    //    }
    //}

}
