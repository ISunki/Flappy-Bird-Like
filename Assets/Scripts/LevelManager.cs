using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels;

    public int currentLevelID = 1;

    public Level level;

    private Game game;
    
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindObjectOfType<Game>().GetComponent<Game>();
        game.OnGame += StartGame;
    }

    void StartGame()
    {
        LoadLevel(currentLevelID);
    }

    public void LoadLevel(int levelID)
    {
        level = Instantiate<Level>(levels[levelID - 1]);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
