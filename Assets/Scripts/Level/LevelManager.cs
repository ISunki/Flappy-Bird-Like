using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels;
    [SerializeField] private Text levelText;

    public int currentLevelID = 1;

    public Level level;

    private Game game;

    
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindObjectOfType<Game>().GetComponent<Game>();
        game.OnGame += StartGame;
        game.EndGame += EndGame;
        game.ReStartGame += StartGame;
    }

    private void UpdateUI()
    {
        levelText.text = "Level " + currentLevelID;
    }

    private void EndGame()
    {
        if (game.isSuccess)
        {
            currentLevelID++;
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
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
