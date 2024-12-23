using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //나는 그냥 무기를 불러옴(무기에 대한정보? 다 알아서 가져라)

    //[SerializeField] private Transform shootTransform;
    [SerializeField] private GameObject[] weaponsList = new GameObject[3];
    [SerializeField] private GameObject[] ownWeapons = new GameObject[3];
    //bool 각 무기에 대한 현재 소유 T or F, 아니면 자료구조 돌린다.
    
    public void FireOwnWeapon()// 플레이어로 부터 호출이 오면 아래있는 놈들을 다 누른다.
    {
        foreach (GameObject ownWeapon in ownWeapons) //각 무기에 대한 반복문, 처음에 선언한 bool값으로 해당 반복문에 진입 여부를 결정함
        {
            Weapon weapon = ownWeapon.GetComponent<Weapon>();
            weapon.Attack(transform.position);
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
            if(ownWeapons[i] == null)//유니티리스트 빈게 null인지확인
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
