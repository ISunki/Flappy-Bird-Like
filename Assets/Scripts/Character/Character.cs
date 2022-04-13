using System;
using UnityEngine;
public abstract class Character : MonoSingleton<Character>
{
    public float speed = 1f;
    public float fireRate = 1f;
    public float power;
    public AudioClip expolosionSFX;
    [SerializeField] protected GameObject expolosionVFX;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;
    
    protected float timer = 0;
    protected Health Health;
    protected Game game;
    protected bool isDead = false;
    
    protected virtual void OnStart()
    {
        game = Game.Instance;
        Health = GetComponent<Health>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (Health.hp <= 0 && !isDead)
        {
            Die();
        }
        Fly();
        Fire();
        OnUpdate();
    }

    protected virtual void OnUpdate() {}


    protected virtual void Fire()
    {
        if (timer > 1 / fireRate)
        {
            timer = 0;
            GameObject ins = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            ins.transform.SetParent(transform.parent);
        }
    }

    protected abstract void Fly();

    protected abstract void Die();

    protected virtual void TakeDamage(float damage)
    {
        Health.hp -= damage;
    }

    protected abstract void Init();
}