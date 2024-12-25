using System;
using System.Collections.Generic;
using UnityEngine;

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

    public enum AbilityType
    {
        Damage,
        Speed,
        CoolTime,
        Range
    }

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

    private void Upgrade(string weaponType, AbilityType ablityType) 
    {
        if (weaponType != gameObject.tag)
        {
            return;
        }
        switch (ablityType) 
        {
            case AbilityType.Damage:
                weaponDamage += damageCoefficient;
                break;
            case AbilityType.Speed:
                weaponSpeed += speedCoefficient;
                break;
            case AbilityType.CoolTime:
                weaponCoolTime -= coolTimeCoefficient;
                break;
            case AbilityType.Range:
                weaponRange += rangeCoefficient;
                break;
        }
    }
}