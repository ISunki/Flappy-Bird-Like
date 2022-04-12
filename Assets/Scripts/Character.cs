using System;
using UnityEngine;
public abstract class Character : MonoBehaviour
{
    public float speed = 1f;
    public float fireRate = 1f;
    public float power;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;


    protected float timer = 0;
    protected Health Health;
    protected Game game;
    
    protected virtual void OnStart()
    {
        game = GameObject.FindObjectOfType<Game>().GetComponent<Game>();
        Health = GetComponent<Health>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (Health != null && Health.hp <= 0)
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