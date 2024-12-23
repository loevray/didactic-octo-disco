using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public int weaponDamage = 1;
    [SerializeField] public float weaponSpeed = 5f;
    [SerializeField] public float weaponCoolTime= 1f;
    [SerializeField] public float weaponRange = 3f;

    public int damageCoefficient = 0;
    public float speedCoefficient = 0f;
    public float CoolTimeCoefficien = 0f;
    public float RangeCoefficient = 0f;

    //private Dictionary<string, float> stats;

    private float weaponlastShotTime;

    public enum AbilityType
    {
        Damage,
        Speed,
        CoolTime,
        Range
    }

    protected virtual void Start()
    {
        weaponlastShotTime = Time.time - weaponCoolTime;
        //stats = new Dictionary<string, float>
        //{
        //    {"weaponDamage", weaponDamage },
        //    {"weaponSpeed", weaponSpeed },
        //    {"weaponCoolTime", weaponCoolTime },
        //    {"weaponRange", weaponRange },
        //};
    }


    protected virtual void Update()
    {
        WeaponMove();
        WeaponDeleteThreshold();
    }

    void WeaponDeleteThreshold()
    {
        if(transform.position.z >= weaponRange)
        {
            Destroy(gameObject);
        }
    }
    void WeaponMove()
    {
        transform.Translate(Vector3.forward * weaponSpeed * Time.deltaTime);
    }

    public void Attack(Vector3 position)
    {
        
        if (Time.time - weaponlastShotTime >= weaponCoolTime) 
        {
            Instantiate(gameObject, position, Quaternion.identity);
            weaponlastShotTime = Time.time;
        }
    }

    private void Upgrade(string weaponType, AbilityType ablityType) //weaponType은 태그로 처리
    {
        if (weaponType != gameObject.tag) 
        {
            return;
        }
        switch (ablityType) //오버라이드
        {
            case AbilityType.Damage:
                weaponDamage += damageCoefficient;
                break;
            case AbilityType.Speed:
                weaponSpeed += speedCoefficient;
                break;
            case AbilityType.CoolTime:
                weaponCoolTime -= CoolTimeCoefficien;
                break;
            case AbilityType.Range:
                weaponRange += RangeCoefficient;
                break;
        }
    }
}
