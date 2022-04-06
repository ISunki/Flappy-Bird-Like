using System;
using UnityEngine;
public class Character : MonoBehaviour
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float fireRate = 1f;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;


    protected float timer = 0;
    protected Health Health;
    protected Game game;

    private void Start()
    {
        game = GameObject.FindWithTag("Player").GetComponent<Game>();
        Health = GetComponent<Health>();
        OnStart();
    }
    
    protected virtual void OnStart() { }

    private void Update()
    {
        OnUpdate();
        timer += Time.deltaTime;
        if (Health != null && Health.hp <= 0)
        {
            Die();
        }
    }

    protected virtual void OnUpdate() { }

    protected virtual void Fire() { }

    protected virtual void Fly() { }
    
    protected virtual void Die() { }
   
    
    protected virtual void Init() { }
    
    
}