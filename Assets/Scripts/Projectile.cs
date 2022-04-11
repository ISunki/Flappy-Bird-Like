using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private BulletType bulletType;

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
        else
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
