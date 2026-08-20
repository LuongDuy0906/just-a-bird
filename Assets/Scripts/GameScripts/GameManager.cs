using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int score)
    {
        this.score += score;
        Debug.Log("Score: " + this.score);
    }

    public int GetScore() { return this.score; }
}
