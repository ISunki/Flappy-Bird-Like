using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float destroyTime = 3f;

    private Game game;

    private void Start()
    {
        game = GameObject.FindWithTag("Player").GetComponent<Game>();

    }

    private void Update()
    {
        if(game.gameStatus == Game.GameStatus.OnGame)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        Destroy(gameObject, destroyTime);
    }
}