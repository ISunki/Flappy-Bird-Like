using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject readyPanel;
    [SerializeField] GameObject onGamePanel;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] Button startButton;


    public enum GameStatus
    {
        Ready,
        OnGame,
        GameOver
    }

    public GameStatus gameStatus = GameStatus.Ready;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
