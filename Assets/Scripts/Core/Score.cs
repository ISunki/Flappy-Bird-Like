using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoSingleton<Score>
{
    [SerializeField] Text onGameScore;
    [SerializeField] Text endScore;
    [SerializeField] Text bestScore;
    
    int scoreNumber = 0;
    private int bestNumber = 0;
    private int currentNum;

    // Start is called before the first frame update
    void Start()
    {
        Game.Instance.OnGame += Init;
        Game.Instance.EndGame += EndGame;
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
        if (Game.Instance.isSuccess)
        {
            currentNum = scoreNumber;
        }
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
        if (!Game.Instance.isSuccess)
        {
            if (LevelManager.Instance.currentLevelID == 1)
            {
                scoreNumber = 0;
            }
            else
            {
                scoreNumber = currentNum;
            }
        }
    }
    
    

}
