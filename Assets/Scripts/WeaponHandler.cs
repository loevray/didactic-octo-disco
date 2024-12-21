using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Transform shootTransform;
    [SerializeField] private GameObject weaponPrefab1;
    //[SerializeField] private GameObject weaponPrefab2;
    //[SerializeField] private GameObject weaponPrefab3;

    private float lastShotTime = 0f;
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
        Weapon weapon = weaponPrefab1.GetComponent<Weapon>();
        if(Time.time - lastShotTime > weapon.weaponCoolTime)
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }
}
