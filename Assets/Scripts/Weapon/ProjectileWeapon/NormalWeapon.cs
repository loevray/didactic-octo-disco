using System;
using UnityEngine;

public class NormalWeapon : DefaultProjectileWeapon
{
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
