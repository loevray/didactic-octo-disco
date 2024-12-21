using UnityEngine;

public class Weapon : MonoBehaviour
{
   
    [SerializeField] public int weaponDamage = 1;
    [SerializeField] protected float weaponSpeed = 5f;
    [SerializeField] public float weaponCoolTime= 1f;
    [SerializeField] protected float weaponRange = 3f;

    protected virtual void Update()
    {
        WeaponMove();
        WeaponDeleteThreshold();
    }

    void WeaponDeleteThreshold()
    {
        if(transform.position.z >= weaponRange)
        {
            Destroy(gameObject);
        }
    }

    void WeaponMove()
    {
        transform.Translate(Vector3.forward * weaponSpeed * Time.deltaTime);
    }
}
