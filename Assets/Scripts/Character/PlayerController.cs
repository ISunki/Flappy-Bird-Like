using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private HPBar hpBar;
    [SerializeField] private float invincibleTime;
    [SerializeField] private AudioClip shotSFX;

    private bool isFire = false;
    Vector3 initPosition;

    Rigidbody2D rb;
    Animator animator;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    
    private static readonly int IsDead = Animator.StringToHash("isDead");
    private static readonly int CollisionTri = Animator.StringToHash("collision");


    protected void Start()
    {
        OnStart();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        initPosition = transform.localPosition;

        game.OnGame += Init;
    }
    
    protected override void OnUpdate() { }

    protected override void Fire()
    {
        if (timer > 1 / fireRate && Input.GetButton("Fire1") && game.gameStatus == GameStatus.OnGame)
        {
            timer = 0;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Game.Instance.PlayOneShot(shotSFX);
        }  
    }


    protected override void Fly()
    {
        if (game.gameStatus != GameStatus.OnGame) return;

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        transform.position += new Vector3(x, y) * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy"))
        {
            Health.hp = Health.hp - 2f;
            animator.SetTrigger(CollisionTri);
        }
        if (col.tag.Equals("EnemyBullet"))
        {
            TakeDamage(col.GetComponent<Projectile>().power);
            Destroy(col.gameObject);
        }
        if (col.tag.Equals("Missile"))
        {
            TakeDamage(col.GetComponent<Projectile>().power);
            Destroy(col.gameObject);
        }
    }

    protected override void Die()
    {
        isDead = true;
        game.GameOver();
        spriteRenderer.enabled = false;
        Instantiate(expolosionVFX, transform.position, Quaternion.identity);
        Game.Instance.PlayOneShot(expolosionSFX);
    }

    protected override void Init()
    {
        isDead = false;
        Health.hp = Health.iniHp;
        spriteRenderer.enabled = true;
        transform.localPosition = initPosition;
    }

    IEnumerator Respawn()
    {
        rb.simulated = false;
        yield return new WaitForSeconds(invincibleTime);
        rb.simulated = true;

    }
}
