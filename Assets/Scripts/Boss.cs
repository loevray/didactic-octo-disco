using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float BossEnemyMoveSpeed = 15f;
    [SerializeField] private int bossEnemyHealthPoint = 100;
    [SerializeField] private GameObject exp;

    private bool isBossStoped = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    void Update()
    {
        MoveBossEnemy();
    }
    void MoveBossEnemy()
    {
        if (gameObject.tag == "BossEnemy" && transform.position.z <= 11)
        { 
            return;
        }
        transform.position += Vector3.back * BossEnemyMoveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            bossEnemyHealthPoint -= weapon.weaponDamage;
            if (bossEnemyHealthPoint <= 0)
            {
                Instantiate(exp, transform.position, Quaternion.identity); //추후에 더 큰 경험치, 보상등으로 교체
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }

}
