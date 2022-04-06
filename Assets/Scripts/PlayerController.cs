using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private HPBar hpBar;

    private bool isFire = false;
    Vector3 initPosition;

    Rigidbody2D rb;
    Game game;
    Animator animator;
    AudioSource audioSource;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    Health health;
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
        health = GetComponent<Health>();
        initPosition = transform.localPosition;

        game.OnGame += StartGame;
        game.ReStartGame += Init;
    }

    private void StartGame()
    {
        hpBar.UpdateUI(health);

    }
    
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        Fly();
        timer += Time.deltaTime;
        if (timer > 1 / fireRate && Input.GetButton("Fire1") && game.gameStatus == Game.GameStatus.OnGame)
        {
            timer = 0;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        }

        if (health.hp <= 0)
        {
            Die();
        }

    }
    

    private void Fly()
    {        
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        transform.position += new Vector3(x, y) * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.tag.Equals("PlayerBullet"))
        {
            if (col.tag.Equals("Enemy"))
            {
                health.hp = 0;
                hpBar.UpdateUI(health);
            }
            health.hp--;
            hpBar.UpdateUI(health);
        }
    }

    private void Die()
    {
        game.GameOver();
        spriteRenderer.enabled = false;
        // boxCollider2D.enabled = false;
        // Instantiate(hitVFX, transform);
        // animator.SetBool(id: IsDead, true);
    }

    private void Init()
    {
        health.hp = health.iniHp;
        spriteRenderer.enabled = true;
        transform.localPosition = initPosition;
        // animator.SetBool(IsDead, false);
        // boxCollider2D.enabled = true;
    }
}
