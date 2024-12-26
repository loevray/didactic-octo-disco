using System.Collections.Generic;
using UnityEngine;
public class CardManager : Singleton<CardManager>
{
    public HashSet<Card> cardPool = new HashSet<Card>();
    private float newWeaponChance = 0.3f;
    private float upgradeCardChance = 0.5f;
    private float speedBoostChance = 0.2f;

    public void GenerateCardPool()
    {
        cardPool.Clear(); // 기존 카드 풀을 초기화
        Debug.Log("Card Pool Cleared" + cardPool.Count);
        
        bool isNewWeapon = true;
        

        while (cardPool.Count < UIManager.Instance.cardButtons.Length)
        {
            float rand = Random.Range(0f, 1f);
            if (isNewWeapon && rand < newWeaponChance)
            {
                cardPool.Add(new Card(CardType.NewWeapon, WeaponType.Strong));
                isNewWeapon = false;
                Debug.Log("Added New Weapon Card");
            }
            else if (!isNewWeapon && rand < newWeaponChance + upgradeCardChance)
            {
                WeaponAbilityType ability = (WeaponAbilityType)Random.Range(0, 4);
                cardPool.Add(new Card(CardType.WeaponUpgrade, weaponAbilityType: ability));
                Debug.Log("Added Weapon Upgrade Card");
            }
            else if (rand < newWeaponChance + upgradeCardChance + speedBoostChance)
            {
                cardPool.Add(new Card(CardType.SpeedBoost));
                Debug.Log("Added Speed Boost Card");
            }
        }

        Debug.Log("Card Pool Generated with " + cardPool.Count + " cards.");
    }

    public void ApplyCard(Card card)
    {
        switch (card.cardType)
        {
            case CardType.NewWeapon:
                Debug.Log("New Weapon: " + card.weaponType);
                break;
            case CardType.WeaponUpgrade:
                Debug.Log("Upgrade Weapon: " + card.weaponType + " " + card.weaponAbilityType);
                break;
            case CardType.SpeedBoost:
                Debug.Log("Speed Boost!");
                break;
        }
    }
}
