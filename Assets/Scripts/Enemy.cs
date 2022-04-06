using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField]  float minOffset = -3;
    [SerializeField]  float maxOffset = 3;
    [SerializeField] private float speed = 1f;

    [SerializeField] private float fireRate = 1f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private Health health;
    private Game game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindWithTag("Player").GetComponent<Game>();
        health = GetComponent<Health>();
        Init();
    }

    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1 / fireRate)
        {
            timer = 0;
            GameObject ins = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            ins.transform.SetParent(transform);
        }

        transform.position += Vector3.left * Time.deltaTime * speed;

        if (health.hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void Init()
    {
        float offset = Random.Range(minOffset, maxOffset);
        transform.position += new Vector3(0,offset,0); 
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enemy triggered");
        if (col.tag.Equals("PlayerBullet"))
        {
            health.hp--;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}

