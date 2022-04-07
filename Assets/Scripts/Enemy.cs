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

    protected void Start()
    {
        OnStart();
        score = FindObjectOfType<Score>();
        Init();
        Debug.Log("enemy start called");
    }
    
    protected override void Fly()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
    
    protected override void Die()
    {
        Destroy(gameObject);
        score.AddScore();
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
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
    
    protected override void Init()
    {
        float offset = Random.Range(minOffset, maxOffset);
        transform.position += new Vector3(0,offset,0); 
    }
}

