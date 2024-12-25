using System;
using System.Collections.Generic;

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
    private int maxStage = 5;
    
    public List<Card> cardPool;  // 카드 풀
    private float newWeaponChance = 0.2f;  // 새로운 무기 획득 확률
    private float upgradeCardChance = 0.5f;  // 업그레이드 카드 확률
    private float speedBoostChance = 0.3f;  // 이동 속도 증가 카드 확률

    Button abilityButton;
    
    void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    
    public static GameManager Instance{
        get{
            if(instance == null){
                return null;
            }
            return instance;
        }
    }
    void Start() {
            
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ShowCardSelection();
        }
    }
    
    public List<Card> GenerateCardPool() {
        List<Card> pool = new List<Card>();

        // 확률에 맞는 카드 생성
        for (int i = 0; i < 10; i++) {
            float rand = UnityEngine.Random.Range(0f, 1f);

            if (rand < newWeaponChance) {
             
                
                pool.Add(new Card(CardType.NewWeapon, WeaponType.Weapon1)); 
            } else if (rand < newWeaponChance + upgradeCardChance) {
                AbilityType upgradeAbility = (AbilityType)UnityEngine.Random.Range(0, 4);  
                pool.Add(new Card(CardType.WeaponUpgrade, abilityType: upgradeAbility)); 
            } else if (rand < newWeaponChance + upgradeCardChance + speedBoostChance) {
                pool.Add(new Card(CardType.SpeedBoost)); 
            }
        }

        return pool;
    }
  
    public void NextStage() {
        if (currentStage < maxStage) {
            currentStage++;
            OnNextStage?.Invoke();
        } else {
            Debug.Log("게임 클리어!");
        }
    }
    // 2. 카드 선택
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
        Debug.Log("카드 선택: " + cardIndex);
        cardSelectionUI.SetActive(false);  
        Time.timeScale = 1;  
    }

}
