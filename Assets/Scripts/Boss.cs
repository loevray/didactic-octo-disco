using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float BossEnemyMoveSpeed = 15f;
    [SerializeField] private int bossEnemyHealthPoint = 100;

    private bool isBossStoped = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    void Update()
    {
        MoveBossEnemy();
        
        //test용 보스 파괴 코드
        if (Input.GetKeyDown(KeyCode.Z)) {
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy() {
        //보스 죽었을시 이벤트 실행
      
    }

    void MoveBossEnemy()
    {
        if (gameObject.tag == "BossEnemy" && transform.position.z <= 11)
        { 
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
    //            Instantiate(Exp, transform.position, Quaternion.identity); //���Ŀ� �� ū ����ġ, ��������� ��ü
    //            Destroy(gameObject);
    //        }
    //    }
    //}

}
