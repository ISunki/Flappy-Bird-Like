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
    [SerializeField] GameObject HitVFX;

    Vector3 initPosition;

    Rigidbody2D rb;
    Game game;
    Animator animator;
    AudioSource audioSource;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    private static readonly int IsDead = Animator.StringToHash("isDead");


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        game = GetComponent<Game>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (other.gameObject.CompareTag("Pipe"))
        {
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

    private void Die()
    {
        game.GameOver();
        boxCollider2D.enabled = false;
        animator.SetBool(id: IsDead, true);
        isDead = true;
        Instantiate(HitVFX, transform);
        spriteRenderer.enabled = false;
    }

    private void Init()
    {
        
        transform.position = initPosition;
        rb.simulated = false;
        boxCollider2D.enabled = true;
        animator.SetBool(IsDead, false);
        isDead = false;
        spriteRenderer.enabled = true;
    }
}