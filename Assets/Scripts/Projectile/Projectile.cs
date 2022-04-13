using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] private BulletType bulletType;
    public float power = 1f;

    private Vector3 targetPos;
    private void Start()
    {
        targetPos = GameObject.FindWithTag("Player").transform.position;
    }
    

    void Update()
    {
        if (bulletType == BulletType.EnemyBullet)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        else if(bulletType == BulletType.BossBullet)
        {
            transform.position += (targetPos - transform.position).normalized * Time.deltaTime * speed;
        }
        else if(bulletType == BulletType.PlayerBullet)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
