using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Missile : Projectile
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private float angleChangingSpeed = 100f;
    
    private Rigidbody2D rb;
    private Transform target;

    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    private void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float rotationAmount = Vector3.Cross(direction,transform.right).z;
        
        rb.angularVelocity = - angleChangingSpeed * rotationAmount;
        rb.velocity = transform.right * speed;
        
    }
}
    