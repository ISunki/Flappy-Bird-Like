using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Character
{
    [SerializeField]  float minOffset = -3;
    [SerializeField]  float maxOffset = 3;
    
    private Score score;
    
    protected override void OnStart()
    {
        score = FindObjectOfType<Score>();
        Init();
        Debug.Log("enemy onstart called");

    }


    protected override void OnUpdate()
    {
        Fly();
        Fire();
    }

    protected override void Fire()
    {
        if (timer > 1 / fireRate)
        {
            timer = 0;
            GameObject ins = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            ins.transform.SetParent(transform.parent);
        }
    }

    protected override void Fly()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("PlayerBullet"))
        {
            Health.hp--;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected override void Die()
    {
        Destroy(gameObject);
        score.AddScore();
    }

    protected override void Init()
    {
        float offset = Random.Range(minOffset, maxOffset);
        transform.position += new Vector3(0,offset,0); 
    }
}

