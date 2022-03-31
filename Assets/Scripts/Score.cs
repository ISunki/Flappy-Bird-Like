using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreText2;

    int scoreNumber = 0;

    Game game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindWithTag("Player").GetComponent<Game>();
        game.ReStartGame += Init;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = scoreNumber.ToString();
        scoreText2.text = scoreNumber.ToString();
    }

    public void AddScore()
    {
        scoreNumber ++;
    }

    public void Init()
    {
        scoreNumber = 0;
    }

}
