using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private float smoothingFactor = 5f;
    private Slider healthBar;
    private Health playerHealth;
    private Game game;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        game = GameObject.FindWithTag("Player").GetComponent<Game>();

        healthBar.maxValue = playerHealth.iniHp;

        Init();
        game.ReStartGame += Init;
    }

    private void Init()
    {
        healthBar.value = playerHealth.iniHp;
    }

    void Update()
    {
        if (!healthBar.value.Equals(playerHealth.hp))
        {
            healthBar.value = Mathf.Lerp(healthBar.value, playerHealth.hp, Time.deltaTime * smoothingFactor);
        }
          
    }
}
