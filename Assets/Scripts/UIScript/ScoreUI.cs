using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextMesh;

    private void Update()
    {
        UpdateScoreTextMesh();
    }
    
    private void UpdateScoreTextMesh()
    {
        scoreTextMesh.text = GameManager.Instance.GetScore().ToString();
    }

}
