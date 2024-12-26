using System;
using UnityEngine;

public class DefaultSummonWeapon : Weapon
{
    private Transform player;
    [SerializeField] private float followSpeed = 1f;
    [SerializeField] private float followDistance = 2f;
    public float projectileCoolTime = 1f;
    public GameObject SummonsWeapon; // squidInkPrefab
    
    private void Awake()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.SummonPet);
    }
    protected override void Start()
    {
        base.Start();
        weaponCoolTime = 2f;
        FindPlayerPosition();
    }

    void Update()
    {
        FollowPlayer();
        GenerateSummonsWeapon();
    }

    void FindPlayerPosition()
    {
        Player playerObject = FindFirstObjectByType<Player>();
        player = playerObject.transform;
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
        if (player == null) return;

        float distance = Mathf.Abs(DistanceWithPlayerX());
        if (distance > followDistance)
        {
            MoveTowardPlayer();
        }
    }

    public override void Generate(Vector3 position)
    {
        base.Generate(position);
    }

    void GenerateSummonsWeapon()
    {
        Vector3 shootPositionModifiy = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        if ((DateTime.Now - weaponLastShotTime).TotalSeconds >= projectileCoolTime)
        {
            GameObject instance = Instantiate(SummonsWeapon, shootPositionModifiy, Quaternion.identity);
            SummonsWeapon summonsWeaponScript = instance.GetComponent<SummonsWeapon>();
            weaponLastShotTime = DateTime.Now;
        }
    }
}
