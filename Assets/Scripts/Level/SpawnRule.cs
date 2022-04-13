using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRule : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] private float spawnTime;
    [SerializeField] private float waitTime;
    [SerializeField] private int maxAmount;
    [SerializeField] private float hp;
    [SerializeField] private float flySpeed;
    
    private int spawnAmount = 0;
    
    Transform spawnPoint;
    
    private void Start()
    {
        spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
        Game.Instance.EndGame += EndGame;
        StartGenerate();
    }

    private void EndGame()
    {
        foreach (Transform child in spawnPoint)
        {
            Destroy(child.gameObject);
        }
    }

    void StartGenerate()
    {
        StartCoroutine(Gen());
    }
    
    IEnumerator Gen()
    {
        yield return new WaitForSeconds(spawnTime);
        while (spawnAmount <= maxAmount)
        {
            GameObject ins = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            ins.transform.SetParent(spawnPoint);
            ins.GetComponent<Health>().iniHp = hp;
            ins.GetComponent<Enemy>().speed = flySpeed;
            spawnAmount++;
            yield return new WaitForSeconds(waitTime);
        } 
        

    }
}
