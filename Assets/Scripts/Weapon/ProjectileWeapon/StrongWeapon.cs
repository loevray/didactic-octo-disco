using UnityEngine;

public class StrongWeapon : DefaultProjectileWeapon
{
    [SerializeField] private float rotationSpeed = 360f; // 1초에 360도 회전
    private Rigidbody rb;
    public override int damageCoefficient
    {
        get => 10;
        set => base.damageCoefficient = value;
    }

    public override float speedCoefficient
    {
        get => 2f;
        set => base.speedCoefficient = value;
    }

    public override float coolTimeCoefficient
    {
        get => 0.5f;
        set => base.coolTimeCoefficient = value;
    }

    public override float rangeCoefficient
    {
        get => 5f;
        set => base.rangeCoefficient = value;
    }

    private void Awake()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.ShootStrongWeapon);
        rb = GetComponent<Rigidbody>();
    }

    protected override void Start()
    {
        base.Start();
        rb.linearVelocity = transform.forward * weaponSpeed;
    }

    protected override void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {
        RotateWeapon();
    }

    private void RotateWeapon()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
