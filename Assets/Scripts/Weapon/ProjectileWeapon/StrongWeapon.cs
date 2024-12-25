using UnityEngine;

public class StrongWeapon : DefaultProjectileWeapon
{
    //긴 쿨타임, 강력한 데미지

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
