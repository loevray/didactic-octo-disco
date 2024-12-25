using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {
    public GameObject cardSelectionUI;
    public Button[] cardButtons;

    public void ShowCardSelectionUI(bool show) {
        cardSelectionUI.SetActive(show);
        Time.timeScale = show ? 0 : 1;
    }

    public void InjectCardInfo() {
        List<Card> cardList = new List<Card>(CardManager.Instance.cardPool);
        
        for (int i = 0; i < cardButtons.Length; i++) {
            Card card = cardList[i];
            Button button = cardButtons[i];
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();

            buttonText.text = card.cardType.ToString();
            button.onClick.RemoveAllListeners();

            int capturedIndex = i;
            button.onClick.AddListener(() => OnCardSelected(capturedIndex));
        }
    }

    public void OnCardSelected(int index) {
        Card selectedCard = new List<Card>(CardManager.Instance.cardPool)[index];
        CardManager.Instance.ApplyCard(selectedCard);
        ShowCardSelectionUI(false);
    }
}
