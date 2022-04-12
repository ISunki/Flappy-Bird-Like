using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private int levelID;
    [SerializeField] private float bossSpawnTime = 30f;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private float bossHp;

    public List<SpawnRule> rules = new List<SpawnRule>();

    private bool isBossSpawned = false;
    private float timeSinceStart = 0f;
    
    Transform bossParent;
    
    void Start()
    {
        bossParent = FindObjectOfType<Camera>().transform;
        for (int i = 0; i < rules.Count ; i++)
        {
            SpawnRule rule = Instantiate<SpawnRule>(rules[i], transform);
        }
    }

    void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart > bossSpawnTime & !isBossSpawned)
        {
            GameObject boss = Instantiate(bossPrefab, bossParent);
            boss.GetComponent<Health>().iniHp = bossHp;
            isBossSpawned = true;
        }
    }
}
