using System;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAbilityType{
  Damage,
  CoolTime,
  Speed,
  Range
}


public class Weapon : MonoBehaviour
{
    [SerializeField] public int weaponDamage = 1;
    [SerializeField] public float weaponSpeed = 5f;
    [SerializeField] public float weaponCoolTime = 1f;
    [SerializeField] public float weaponRange = 3f;

    public int damageCoefficient = 0;
    public float speedCoefficient = 0f;
    public float coolTimeCoefficient = 0f;
    public float rangeCoefficient = 0f;
    protected Vector3 weaponPosition;

    protected DateTime weaponLastShotTime;


    private void Awake()
    {
        weaponLastShotTime = DateTime.MinValue;
    }

    protected virtual void Start()
    {
        // weaponLastShotTime 초기화는 Awake에서만 수행
        // weaponLastShotTime = DateTime.MinValue;
        //stats = new Dictionary<string, float>
        //{
        //    {"weaponDamage", weaponDamage },
        //    {"weaponSpeed", weaponSpeed },
        //    {"weaponCoolTime", weaponCoolTime },
        //    {"weaponRange", weaponRange },
        //};
    }

    public virtual void Generate(Vector3 position)
    {
        if ((DateTime.Now - weaponLastShotTime).TotalSeconds >= weaponCoolTime)
        {
            Instantiate(gameObject, position, Quaternion.identity);
            weaponLastShotTime = DateTime.Now;
        }
    }

    public void Upgrade(WeaponAbilityType weaponAbilityType) 
    {
        switch (weaponAbilityType) 
        {
            case WeaponAbilityType.Damage:
                weaponDamage += damageCoefficient;
                break;
            case WeaponAbilityType.Speed:
                weaponSpeed += speedCoefficient;
                break;
            case WeaponAbilityType.CoolTime:
                weaponCoolTime -= coolTimeCoefficient;
                break;
            case WeaponAbilityType.Range:
                weaponRange += rangeCoefficient;
                break;
        }
    }
}
