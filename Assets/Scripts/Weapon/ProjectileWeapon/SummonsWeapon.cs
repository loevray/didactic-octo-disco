using UnityEngine;

public class SummonsWeapon : DefaultProjectileWeapon
{
    private DefaultSummonWeapon summonWeapon; 

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (summonWeapon != null)
        {
            transform.position = summonWeapon.transform.position;
        }
    }
}