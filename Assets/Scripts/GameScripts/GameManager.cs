using System;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    WAITING,
    PLAYING,
    GAMEOVER
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; } = GameState.WAITING;

    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private GameObject readyUI;
    [SerializeField] private GameObject scoreUI;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetState(GameState.WAITING);
    }

    public void AddScore(int score)
    {
        if (CurrentState != GameState.PLAYING) return;
        this.score += score;
        Debug.Log("Score: " + this.score);
    }

    public int GetScore() { return this.score; }


    public void GameOver()
    {
        if(CurrentState == GameState.GAMEOVER)
        {
            return;
        }
        SetState(GameState.GAMEOVER);
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;

        switch (newState) {
            case GameState.WAITING:
                Debug.Log("Game State: WAITING");
                Time.timeScale = 0f;
                readyUI.SetActive(true);
                gameOverUI.gameObject.SetActive(false);
                scoreUI.SetActive(false);
                break;
            case GameState.PLAYING:
                Debug.Log("Game State: PLAYING");
                Time.timeScale = 1f;
                scoreUI.gameObject.SetActive(true);
                readyUI.SetActive(false);
                score = 0;
                break;
            case GameState.GAMEOVER:
                Debug.Log("Game State: GAMEOVER");
                Time.timeScale = 0f;
                gameOverUI.ShowGameOver(score);
                scoreUI.SetActive(false);
                readyUI.SetActive(false);
                break;
        }
    }
}
