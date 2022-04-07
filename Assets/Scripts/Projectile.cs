using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    [SerializeField] private bool isEnemyBullet = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isEnemyBullet)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
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
