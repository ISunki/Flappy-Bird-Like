using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] Text onGameScore;
    [SerializeField] Text endScore;
    [SerializeField] Text bestScore;
    
    int scoreNumber = 0;
    private int bestNumber = 0;

    Game game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindObjectOfType<Game>().GetComponent<Game>();
        game.ReStartGame += Init;
        game.EndGame += EndGame;

        bestNumber = PlayerPrefs.GetInt("bestNumber");
    }

    private void EndGame()
    {
        if (scoreNumber > bestNumber)
        {
            bestNumber = scoreNumber;
        }
        bestScore.text = bestNumber.ToString();
        PlayerPrefs.SetInt("bestNumber", bestNumber);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        onGameScore.text = scoreNumber.ToString();
        endScore.text = scoreNumber.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        scoreNumber += scoreToAdd;
    }

    private void Init()
    {
        scoreNumber = 0;
    }
    
    

}
