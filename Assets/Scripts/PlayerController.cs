using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    [SerializeField] bool isDead = false;
    [SerializeField] Score scoreText;
    [SerializeField] AudioClip flySound;

    Vector3 initPosition;

    Rigidbody2D rb;
    Game game;
    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        game = GetComponent<Game>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        initPosition = transform.position;

        rb.simulated = false;
        game.OnGame += StartGame;
        game.ReStartGame += Init;
    }

    private void StartGame()
    {
        rb.simulated = true;
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
        
    }

    private void Fly()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * speed);
            audioSource.PlayOneShot(flySound);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Pipe")
        {
            game.gameStatus = Game.GameStatus.GameOver;
            game.GameOver();
            Die();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "ScoreBoard")
        {
            scoreText.AddScore();      
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);
        isDead = true;
        rb.Sleep();
        
    }

    void Init()
    {
        
        transform.position = initPosition;
        rb.simulated = false;
        rb.WakeUp();
        animator.SetBool("isDead", false);

        isDead = false;

    }
}
