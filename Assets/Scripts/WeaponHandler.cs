using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Transform shootTransform;
    [SerializeField] private GameObject weaponPrefab1;
    [SerializeField] private GameObject weaponPrefab2;
    //[SerializeField] private GameObject weaponPrefab3;

    private float weapon1lastShotTime = 0f;
    private float weapon2lastShotTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        Weapon1();
        Weapon2();
    }

    private void Weapon1()
    {
        Weapon weapon = weaponPrefab1.GetComponent<Weapon>();
        if (Time.time - weapon1lastShotTime > weapon.weaponCoolTime) // 추후 무기 종류에 따른 조정 필요
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            weapon1lastShotTime = Time.time;
        }
    }

    private void Weapon2()
    {
        Weapon weapon = weaponPrefab2.GetComponent<Weapon>();
        if (Time.time - weapon2lastShotTime > weapon.weaponCoolTime) // 추후 무기 종류에 따른 조정 필요
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            weapon2lastShotTime = Time.time;
        }
    }
}
