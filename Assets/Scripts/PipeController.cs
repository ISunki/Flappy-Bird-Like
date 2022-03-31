using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField] float waitTime = 2f;

    Coroutine coroutine = null;
    List<Pipe> pipes = new List<Pipe>();

    
    // Start is called before the first frame update
    void Start()
    {
       
        Game game = GameObject.FindWithTag("Player").GetComponent<Game>();
        game.OnGame += StartGenerate;
        game.EndGame += Stop;
        game.ReStartGame += Init;
    }

    void Init()
    {
        for (int i = 0; i < pipes.Count; i++)
        {
            Destroy(pipes[i].gameObject);
        }
        pipes.Clear();
    }

    void StartGenerate()
    {
        coroutine = StartCoroutine(Gen());
    }

    void Stop()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < pipes.Count; i++)
        {
            pipes[i].enabled = false;
        }
    }

    IEnumerator Gen()
    {
        for (int i = 0; i < 5; i++)
        {
            if (pipes.Count < 5)
            {
                Generate();
            }
            else
            {
                pipes[i].enabled = true;
                pipes[i].Init();
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

    void Generate()
    {
        if (pipes.Count < 5)
        {              
            GameObject ins = Instantiate(pipe, transform); 
            Pipe p = ins.GetComponent<Pipe>();
            pipes.Add(p);
        }
    }
}
