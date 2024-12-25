using UnityEngine;
using static SummonManager;

public class DefaultSummonWeapon : Weapon
{

    
    [SerializeField] private Transform player; //플레이어의 위치 참조
    [SerializeField] private float followSpeed = 1f;
    [SerializeField] private float followDistance = 2f;
    public float projectileCoolTime = 1f;
    public GameObject SummonsWeapon; // 먹물 프리팹

    protected override void Start()
    {
        base.Start();
        weaponCoolTime = 10000;
    }
    void Update()
    {
        FollowPlayer();
    }
    void Move()
    {

    }
    float DistanceWithPlayerX()
    {
        return player.position.x - transform.position.x;
    }
    void MoveTowardPlayer()
    {
        float distanceX = DistanceWithPlayerX();
        Vector3 direction = new Vector3(distanceX, 0, 0).normalized;
        transform.position += direction * followSpeed * Time.deltaTime;
    }
    void FollowPlayer()
    {
        float distance = Mathf.Abs(DistanceWithPlayerX());
        if (distance > followDistance)
        {
            MoveTowardPlayer();
        }
    }

    //(Time.time - weaponlastShotTime >= weaponCoolTime) 
    public override void Generate(Vector3 position)//베이스 제너레이트=오징어가 소환되는 위치, 새로 인스턴시에이트 = 먹물
    {
        base.Generate(position);
        GenerateSummonsWeapon();
    }

    //-900000
    void GenerateSummonsWeapon()
    {

        if (Time.time - weaponlastShotTime >= projectileCoolTime) 
        {
            Debug.Log(weaponPosition);
            GameObject sex = Instantiate(SummonsWeapon, weaponPosition, Quaternion.identity);
            weaponlastShotTime = Time.time;
        }
    }

    //public void OnEnable()//소환수 카드 획득시 작동
    //{
    //    SummonPet();
    //}
    //void SummonPet()
    //{
    //    Vector3 summonPosition = player.position + new Vector3(2, 0, 1);
    //    Instantiate(gameObject, summonPosition, Quaternion.identity);
    //}
}
