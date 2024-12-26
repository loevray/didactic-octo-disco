using UnityEngine;

public class SummonsWeapon : DefaultProjectileWeapon
{
    private DefaultSummonWeapon summonWeapon;
    private void Awake()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.ShootSummonsWeapon);
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