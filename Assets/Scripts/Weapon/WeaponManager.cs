using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    [SerializeField] private GameObject[] weaponsList = new GameObject[3];
    [SerializeField] private GameObject[] ownWeapons = new GameObject[3];
    
    public void FireOwnWeapon()
    {
        foreach (GameObject ownWeapon in ownWeapons)
        {
            Weapon weapon = ownWeapon.GetComponent<Weapon>();
            weapon.Generate(transform.position);
        }
    }

    //새로운 무기 선택시 리스트에 넣는 메소드
    public void EquimentWeapon(WeaponType weaponType)
    {
        GameObject newWeapon = weaponsList[(int)weaponType];
        ownWeapons[(int)weaponType] = newWeapon;
    }
    public List<WeaponType> GetAvailableWeaponList()
    {
        List<WeaponType> availableWeapons = new List<WeaponType>();
        for (int i =1; i < 3; i++)
        {
            if(ownWeapons[i] == null)
            {
                availableWeapons.Add((WeaponType)(i));
            }
        }
        return availableWeapons;
    }

    public enum WeaponType
    {
        Default,//0 
        Strong,//1
        Pet//2
    }
}
