using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] Button startButton;
    [SerializeField] AudioClip ExplosionSFX;

    public event Action OnGame;
    public event Action EndGame;
    public event Action ReStartGame;

    AudioSource audioSource;

    public GameStatus gameStatus = GameStatus.Ready;
    


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        readyPanel.SetActive(gameStatus == GameStatus.Ready);
        onGamePanel.SetActive(gameStatus == GameStatus.OnGame);
        gameOverPanel.SetActive(gameStatus == GameStatus.GameOver);
    }

    public void StartGame()
    {
        gameStatus = GameStatus.OnGame;
        if (OnGame!= null)
        {
            OnGame();
        }
    }

    public void GameOver()
    {
        gameStatus = GameStatus.GameOver;
        if (EndGame!= null)
        {
            EndGame();
        }
        audioSource.Stop();
        audioSource.PlayOneShot(ExplosionSFX);
    }

    public void ReStart()
    {
        gameStatus = GameStatus.Ready;
        if (ReStartGame != null)
        {
            ReStartGame();
        }
        audioSource.Play();
    }
}
