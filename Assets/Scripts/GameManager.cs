using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    private static GameManager instance = null; 
    public GameObject cardSelectionUI; 
    private bool isPaused = false;

    private int currentStage = 1;
    public int CurrentStage {
        get { return currentStage; }
    }
    public event Action OnNextStage;
    private int maxStage = 2;
    
    public HashSet<Card> cardPool; 
    private float newWeaponChance = 0.2f; 
    private float upgradeCardChance = 0.5f;  
    private float speedBoostChance = 0.3f;  
    public Button[] cardButtons;
    public static GameManager Instance{
        get{
            if(instance == null){
                return null;
            }
            return instance;
        }
    }
    void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    

    void Start() {
            
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            cardPool = GenerateCardPool();
            InjectCardInfoToButtons();
            ShowCardSelection();
        }
    }
    
    public void ApplyCard(Card card) {
        switch (card.cardType) {
            case CardType.NewWeapon:
                Debug.Log("Get New Weapon!: " + card.weaponType);
                break;
            case CardType.WeaponUpgrade:
                Debug.Log("WeaponUpgrade!: " + card.weaponType + " " + card.weaponAbilityType);
                break;
            case CardType.SpeedBoost:
                Debug.Log("Get Player Speed Boost!");
                break;
        }
    }
    
    public HashSet<Card> GenerateCardPool() {
        HashSet<Card> pool = new HashSet<Card>();
        
        //임시 변수
        bool isNewWeapon = true;
        
        while(pool.Count < cardButtons.Length){
            float rand = UnityEngine.Random.Range(0f, 1f);
            if(isNewWeapon && rand < newWeaponChance){
                //일단 하드코딩으로 강한 무기 추가
                pool.Add(new Card(CardType.NewWeapon, WeaponType.Strong)); 
                isNewWeapon = false;
            }   else if(!isNewWeapon && rand < newWeaponChance + upgradeCardChance){
                WeaponAbilityType upgradableWeaponAbility = (WeaponAbilityType)UnityEngine.Random.Range(0, 4);  
                pool.Add(new Card(CardType.WeaponUpgrade, weaponAbilityType: upgradableWeaponAbility));
            }   else if (rand < newWeaponChance + upgradeCardChance + speedBoostChance) {
                pool.Add(new Card(CardType.SpeedBoost)); 
            }
        }

        return pool;
    }
    
    public Card GetNewWeponCard(){
        /* 
            보유하지 않은 무기 배열에서 랜덤으로 하나를 선택하여 반환한다.
            notOwnWeapons[UnityEngine.Random.Range(0, notOwnWeapons.Length)];
         */
        
        return new Card(CardType.NewWeapon, WeaponType.Strong);
    }
  
    public void NextStage() {
        if (currentStage < maxStage) {
            currentStage++;
            OnNextStage?.Invoke();
        } else {
            Debug.Log("게임 클리어!");
        }
    }
    
    private void InjectCardInfoToButtons(){
        List<Card>listedCardPool = new List<Card>(cardPool);
        
        for(int i = 0; i < cardButtons.Length; i++){
            Card card = listedCardPool[i];
            Button button = cardButtons[i];
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
            
            buttonText.text = card.cardType.ToString();
            button.onClick.RemoveAllListeners();
            
            int capturedIndex = i;
            button.onClick.AddListener(() => OnCardSelected(capturedIndex));
        }
    }
    
    public void ShowCardSelection() {
        isPaused = !isPaused;
        cardSelectionUI.SetActive(isPaused);
        
        if (isPaused) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }
    public void OnCardSelected(int cardIndex) {
        Debug.Log("카드 선택! " + cardIndex);
        
        Card selectedCard = new List<Card>(cardPool)[cardIndex];
        ApplyCard(selectedCard);
        
        cardPool.Clear();
        isPaused = false;
        
        cardSelectionUI.SetActive(false);
        Time.timeScale = 1;  
    }

}
