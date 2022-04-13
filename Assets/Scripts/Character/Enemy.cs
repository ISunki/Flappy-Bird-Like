using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Character
{
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
        Destroy(gameObject);
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

