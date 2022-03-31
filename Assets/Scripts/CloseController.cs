using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseController : MonoBehaviour
{
    [SerializeField] GameObject close;
    [SerializeField] float waitTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Game game = GameObject.FindWithTag("Player").GetComponent<Game>();
        game.OnGame += StartGenerate;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StartGenerate()
    {
        StartCoroutine(Gen());
    }

    IEnumerator Gen()
    {
        while (true)
        {
            Generate();
            yield return new WaitForSeconds(waitTime);
        }
    }

    void Generate()
    {

        GameObject ins = Instantiate(close, transform);   
    }
}
