using UnityEngine;

public class DefaultWeapon : Weapon
{
    //�������� �߻�ü

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        damageCoefficient = 2;
        speedCoefficient = 1f;
        CoolTimeCoefficien = 0.3f;
        RangeCoefficient = 1f;
    }

    protected override void Update()
    {
        base.Update();
    }
}
