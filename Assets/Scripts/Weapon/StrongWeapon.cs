using UnityEngine;

public class StrongWeapon : Weapon
{
    //�� ��Ÿ��, ������ ������

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        damageCoefficient = 10;
        speedCoefficient = 2f;
        CoolTimeCoefficien = 1f;
        RangeCoefficient = 5f;
    }

    protected override void Update()
    {
        base.Update();
    }

}
