using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public enum GameStatus
    {
        Ready,
        OnGame,
        GameOver
    }

    [SerializeField] GameObject readyPanel;
    [SerializeField] GameObject onGamePanel;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] AudioClip explosionSfx;

    public event Action OnGame;
    public event Action EndGame;
    public event Action ReStartGame;
    
    public GameStatus gameStatus = GameStatus.Ready;
    public bool isSuccess = false;
    
    private void Update()
    {
        readyPanel.SetActive(gameStatus == GameStatus.Ready);
        onGamePanel.SetActive(gameStatus == GameStatus.OnGame);
        gameOverPanel.SetActive(gameStatus == GameStatus.GameOver);
    }

    public void StartGame()
    {
        gameStatus = GameStatus.OnGame;
        OnGame?.Invoke();
    }

    public void GameOver()
    {
        gameStatus = GameStatus.GameOver;
        EndGame?.Invoke();
    }

    public void ReStart()
    {
        gameStatus = GameStatus.Ready;
        ReStartGame?.Invoke();
    }
}
