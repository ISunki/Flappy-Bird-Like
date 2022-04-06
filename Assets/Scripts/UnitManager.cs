using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float waitTime = 1f;
    private Game game;

    private Coroutine gen;
    void Start()
    {
        game = GameObject.FindWithTag("Player").GetComponent<Game>();
        
        game.OnGame += StartGenerate;
        game.EndGame += Stop;
    }

    private void Stop()
    {
        StopCoroutine(gen);
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void StartGenerate()
    {
        gen = StartCoroutine(Gen());
    }
    
    IEnumerator Gen()
    {
        while (true)
        {
            GameObject ins = Instantiate(enemyPrefab, transform.position, Quaternion.identity); 
            ins.transform.SetParent(transform);
            yield return new WaitForSeconds(waitTime);
        }

    }
    
}
