using UnityEngine;

public class SummonsWeapon : DefaultProjectileWeapon
{
    private DefaultSummonWeapon summonWeapon; // DefaultSummonWeapon의 참조

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        // DefaultSummonWeapon의 위치를 따라다님
        if (summonWeapon != null)
        {
            transform.position = summonWeapon.transform.position;
        }
    }
}