using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int currentStage = 1;
    private int maxStage = 2;

    public int CurrentStage
    {
        get { return currentStage; }
    }

    public event System.Action OnNextStage;

    public void NextStage()
    {
        if (currentStage < maxStage)
        {
            currentStage++;
            OnNextStage?.Invoke();
        }
        else
        {
            Debug.Log("게임 클리어!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CardManager.Instance.GenerateCardPool();
            UIManager.Instance.InjectCardInfo();
            UIManager.Instance.ShowCardSelectionUI(true);
        }
    }
}
