using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField] private Text levelText;
    [SerializeField] private Text nextLevelText;


    public List<Level> levels;
    public int currentLevelID = 1;
    public Level level;

    void Start()
    {
        Game.Instance.OnGame += StartGame;
        Game.Instance.EndGame += EndGame;
        Game.Instance.ReStartGame += StartGame;
    }
    
    private void UpdateUI()
    {
        levelText.text = "Level " + currentLevelID;
    }

    private void EndGame()
    {
        if (Game.Instance.isSuccess)
        {
            currentLevelID++;
            nextLevelText.text = "Next Level";
        }
        else
        {
            nextLevelText.text = "Try again";
        }
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void StartGame()
    {
        LoadLevel(currentLevelID);
        UpdateUI();
    }

    public void LoadLevel(int levelID)
    {
        level = Instantiate<Level>(levels[levelID - 1], transform);
    }
    
}
