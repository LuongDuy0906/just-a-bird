using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalScoreTextMesh;
    [SerializeField] private TextMeshProUGUI bestScoreTextMesh;
    [SerializeField] private Image medalImage;
    [SerializeField] private Sprite bronzeMedalSprite;
    [SerializeField] private Sprite silverMedalSprite;
    [SerializeField] private Sprite goldMedalSprite;
    [SerializeField] private Button gameOverButton;
    [SerializeField] private Button homeButton;
    private const string BEST_SCORE_KEY = "BestScore";

    private void Awake()
    {
        gameOverButton.onClick.AddListener(RestartGame);
        homeButton.onClick.AddListener(GoToHome);
    }

    public void ShowGameOver(int totalScore)
    {
        gameObject.SetActive(true);

        int bestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);

        if (totalScore > bestScore)
        {
            bestScore = totalScore;
            PlayerPrefs.SetInt(BEST_SCORE_KEY, bestScore);
        }

        totalScoreTextMesh.text = totalScore.ToString();
        bestScoreTextMesh.text = bestScore.ToString();

        UpdateMedal(totalScore);
    }

    private void UpdateMedal(int totalScore)
    {
        if (totalScore <= 100)
        {
            medalImage.gameObject.SetActive(true);
            medalImage.sprite = bronzeMedalSprite;

        }
        else if (totalScore <= 200)
        {
            medalImage.gameObject.SetActive(true);
            medalImage.sprite = silverMedalSprite;
        }
        else
        {
            medalImage.gameObject.SetActive(true);
            medalImage.sprite = goldMedalSprite;
        }
    }

    private void RestartGame()
    {
        SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
    }

    private void GoToHome()
    {
        SceneLoader.LoadScene(SceneLoader.Scene.MenuScene);
    }
}
