using UnityEngine;

public class SummonsWeapon : DefaultProjectileWeapon
{
    public override int damageCoefficient { 
        get => 2; 
        set => base.damageCoefficient = value; 
    }

    public override float speedCoefficient
    {
        get => 2f;
        set => base.speedCoefficient = value;
    }

    public override float coolTimeCoefficient
    {
        get => 1f;
        set => base.coolTimeCoefficient = value;
    }

    public override float rangeCoefficient
    {
        get => 5f;
        set => base.rangeCoefficient = value;
    }

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
