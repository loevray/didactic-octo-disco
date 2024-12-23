using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //���� �׳� ���⸦ �ҷ���(���⿡ ��������? �� �˾Ƽ� ������)

    //[SerializeField] private Transform shootTransform;
    [SerializeField] private GameObject[] weaponsList = new GameObject[3];
    [SerializeField] private GameObject[] ownWeapons = new GameObject[3];
    //bool �� ���⿡ ���� ���� ���� T or F, �ƴϸ� �ڷᱸ�� ������.
    
    public void FireOwnWeapon()// �÷��̾�� ���� ȣ���� ���� �Ʒ��ִ� ����� �� ������.
    {
        foreach (GameObject ownWeapon in ownWeapons) //�� ���⿡ ���� �ݺ���, ó���� ������ bool������ �ش� �ݺ����� ���� ���θ� ������
        {
            Weapon weapon = ownWeapon.GetComponent<Weapon>();
            weapon.Attack(transform.position);
        }
    }

    //���ο� ���� ���ý� ����Ʈ�� �ִ� �޼ҵ�
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
            if(ownWeapons[i] == null)//����Ƽ����Ʈ ��� null����Ȯ��
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
