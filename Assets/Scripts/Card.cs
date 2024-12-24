public enum CardType {
    WeaponUpgrade,  // 무기 업그레이드 카드
    NewWeapon,      // 새로운 무기 획득 카드
    SpeedBoost      // 이동 속도 증가 카드
}

public enum WeaponType{
  Default,
  Weapon1,
  Weapon2
}

public enum AbilityType{
  Damage,
  CoolTime,
  Speed,
  Range
}

public class Card {
    public CardType cardType;  // 카드의 종류
    
    public WeaponType weaponType;
    
    public AbilityType abilityType;

    public Card(CardType cardType, WeaponType weaponType = WeaponType.Default, AbilityType abilityType = AbilityType.Damage) {
        this.cardType = cardType;
        this.weaponType = weaponType;
        this.abilityType = abilityType;
    }
}
