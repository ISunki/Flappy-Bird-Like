using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float speed = 1f; 
    public bool isStart = false;
    void Start()
    {
        Game.Instance.OnGame += StartGame;
        Game.Instance.EndGame += EndGame;
    }

    void StartGame()
    {
        isStart = true;
    }
    
    void EndGame()
    {
        isStart = false;
    }
    
    void Update()
    {
        if (isStart)
        {
            transform.position += new Vector3(1,0, 0 ) * Time.deltaTime * speed;
        }
    }
}
