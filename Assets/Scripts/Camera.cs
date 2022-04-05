using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float speed = 1f; 
    public bool isStart = false;
    private Game game;
    void Start()
    {
        Game game = GameObject.FindWithTag("Player").GetComponent<Game>();
        game.OnGame += StartGame;
        game.EndGame += EndGame;
        game.ReStartGame += StartGame;
    }

    void StartGame()
    {
        isStart = true;
    }
    
    void EndGame()
    {
        isStart = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            transform.position += new Vector3(1,0, 0 ) * Time.deltaTime * speed;
        }
    }
}
