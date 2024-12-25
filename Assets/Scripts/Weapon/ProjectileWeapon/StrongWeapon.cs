using UnityEngine;

public class StrongWeapon : DefaultProjectileWeapon
{
    //�� ��Ÿ��, ������ ������

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        damageCoefficient = 10;
        speedCoefficient = 2f;
        coolTimeCoefficient = 1f;
        rangeCoefficient = 5f;
    }

    protected override void Update()
    {
        base.Update();
    }

}
