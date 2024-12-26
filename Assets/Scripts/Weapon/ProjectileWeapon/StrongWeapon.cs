using UnityEngine;

public class StrongWeapon : DefaultProjectileWeapon
{

    private void Awake()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.ShootStrongWeapon);
    }
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
