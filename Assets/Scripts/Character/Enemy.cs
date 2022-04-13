using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Character
{
    [SerializeField] private GameObject potion;
    [SerializeField] private float dropRate = 50;
    [SerializeField]  float minOffset = -3;
    [SerializeField]  float maxOffset = 3;
    
    protected void Start()
    {
        OnStart();
        Init();
    }
    
    protected override void Fly()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
    
    protected override void Die()
    {
        Score.Instance.AddScore(1);
        DrppPotion();
        Game.Instance.PlayOneShot(expolosionSFX);
        Instantiate(expolosionVFX,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void DrppPotion()
    {
        float random = Random.Range(0, 100);
        if (dropRate > random)
        {
            Instantiate(potion, transform.position + new Vector3(0,0.5f), Quaternion.identity);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("PlayerBullet"))
        {
            Health.hp--;
            Destroy(col.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
    protected override void Init()
    {
        float offset = Random.Range(minOffset, maxOffset);
        transform.position += new Vector3(0,offset,0); 
    }
}

