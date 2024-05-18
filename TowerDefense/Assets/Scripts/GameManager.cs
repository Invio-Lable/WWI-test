using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject victoryUI;
    public GameObject defeatUI;
    public Button rewardButton;
    public Button rewardX2Button;
    public Button homeButton;
    public Button retryButton;
    public PlayerCurrency playerCurrency;
    public int rewardAmount = 50;
    public int rewardMultiplier = 2;

    private void Start()
    {
        rewardButton.onClick.AddListener(ClaimReward);
        rewardX2Button.onClick.AddListener(ClaimRewardX2);
        homeButton.onClick.AddListener(ReturnToHome);
        retryButton.onClick.AddListener(RetryLevel);
    }

    public void ShowVictoryUI()
    {
        victoryUI.SetActive(true);
    }

    public void ShowDefeatUI()
    {
        defeatUI.SetActive(true);
    }

    private void ClaimReward()
    {
        playerCurrency.AddCoins(rewardAmount);
        ReturnToHome();
    }

    private void ClaimRewardX2()
    {
        playerCurrency.AddCoins(rewardAmount * rewardMultiplier);
        ReturnToHome();
    }

    private void ReturnToHome()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
