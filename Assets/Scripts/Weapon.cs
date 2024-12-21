using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public int weaponDamage = 5;
    [SerializeField] private float weaponSpeed = 5f;
    [SerializeField] public float weaponCoolTime= 1f;
    [SerializeField] private float weaponRange = 3f;



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * weaponSpeed * Time.deltaTime);
        WeaponDeleteThreshold();
    }

    void WeaponDeleteThreshold()
    {
        if(transform.position.z >= weaponRange)
        {
            Destroy(gameObject);
        }
    }
}
