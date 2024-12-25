using UnityEngine;
using static SummonManager;

public class DefaultSummonWeapon : Weapon
{

    
    [SerializeField] private Transform player; //�÷��̾��� ��ġ ����
    [SerializeField] private float followSpeed = 1f;
    [SerializeField] private float followDistance = 2f;
    public float projectileCoolTime = 1f;
    public GameObject SummonsWeapon; // �Թ� ������

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
    public override void Generate(Vector3 position)//���̽� ���ʷ���Ʈ=��¡� ��ȯ�Ǵ� ��ġ, ���� �ν��Ͻÿ���Ʈ = �Թ�
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

    //public void OnEnable()//��ȯ�� ī�� ȹ��� �۵�
    //{
    //    SummonPet();
    //}
    //void SummonPet()
    //{
    //    Vector3 summonPosition = player.position + new Vector3(2, 0, 1);
    //    Instantiate(gameObject, summonPosition, Quaternion.identity);
    //}
}
