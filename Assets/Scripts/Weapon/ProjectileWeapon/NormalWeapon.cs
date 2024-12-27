using System;
using UnityEngine;

public class NormalWeapon : DefaultProjectileWeapon
{
    public override int damageCoefficient
    {
        get => 2;
        set => base.damageCoefficient = value;
    }

    public override float speedCoefficient
    {
        get => 1f;
        set => base.speedCoefficient = value;
    }

    public override float coolTimeCoefficient
    {
        get => 0.05f;
        set => base.coolTimeCoefficient = value;
    }

    public override float rangeCoefficient
    {
        get => 1f;
        set => base.rangeCoefficient = value;
    }

    private void Awake()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.ShootNormalWeapon);
    }
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
