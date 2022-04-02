using UnityEngine;
using Random = UnityEngine.Random;

public class Pipe : MonoBehaviour
{
    [SerializeField]  float speed = 10f;
    [SerializeField]  float resetTime = 10f;
    [SerializeField]  int minOffset = -3;
    [SerializeField]  int maxOffset = 3;

    float t = 0;


    private Game game;
    // Start is called before the first frame update

    private void Start()
    {
        Init();
        game = GameObject.FindWithTag("Player").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if(game.gameStatus == Game.GameStatus.OnGame)
        {
            Move();
        }
        t += Time.deltaTime;
        if (t > resetTime)
        {
            t = 0;
            Init();
        }
    }

    public void Init()
    {
        int offset = Random.Range(minOffset, maxOffset);
        transform.position = new Vector3(5,offset,0); 
    }
    
    void Move()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
    
    

}
