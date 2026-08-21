using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalScoreTextMesh;
    [SerializeField] private TextMeshProUGUI bestScoreTextMesh;
    [SerializeField] private Image medalImage;
    [SerializeField] private Sprite bronzeMedalSprite;
    [SerializeField] private Sprite silverMedalSprite;
    [SerializeField] private Sprite goldMedalSprite;

    private const string BEST_SCORE_KEY = "BestScore";

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
}
