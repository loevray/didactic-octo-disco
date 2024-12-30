using UnityEngine;

public class BossAttack : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 필요한 초기화 작업이 있다면 여기에 추가
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        deleteOutEnemy();
    }

    // MoveEnemy 메서드를 재정의하여 반대 방향으로 이동하도록 변경
    protected override void MoveEnemy()
    {
        transform.position += Vector3.back * enemyMoveSpeed * Time.deltaTime;
    }

    // CollideWeapon 메서드를 삭제
    private void OnTriggerEnter(Collider other)
    {
        CollidePlayer(other);
    }
}