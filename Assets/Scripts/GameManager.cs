using System;
using System.Collections.Generic;

using UnityEngine;


public class GameManager : MonoBehaviour {
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


    void Start() {
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ShowCardSelection();
        }
    }
    
     List<Card> GenerateCardPool() {
        List<Card> pool = new List<Card>();


        // 확률에 맞는 카드 생성
        for (int i = 0; i < 10; i++) {
            float rand = UnityEngine.Random.Range(0f, 1f);
            
            //WeaponManager에서 ownWeapons 배열을 순회하여 각 무기 종류를 가져옴.
            //게임에 존재하는 무기 종류 - 배열순회 결과가 0보다 크면 그 안에서 새로운 무기 추가
            //만약 0보다 작으면 새로운 무기추가 x

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
        // 카드 선택 로직 (카드 인덱스에 따라 다른 보상 부여)
        Debug.Log("카드 선택: " + cardIndex);
        cardSelectionUI.SetActive(false);  // UI 비활성화
        Time.timeScale = 1;  // 게임 재개
    }

}
