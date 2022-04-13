using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Potion : MonoBehaviour
{
    [SerializeField] float healAmount = 2f;
    [SerializeField] private float dropSpeed = 0.2f;
    [SerializeField] private AudioClip collectionSFX;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if ((col.GetComponent<Health>().hp += healAmount) > col.GetComponent<Health>().iniHp)
            {
                col.GetComponent<Health>().hp = col.GetComponent<Health>().iniHp;
            }
            else
            {
                col.GetComponent<Health>().hp += healAmount;
            }
            Game.Instance.PlayOneShot(collectionSFX);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position += new Vector3(0, -1 * dropSpeed, 0) * Time.deltaTime;
    }
}
