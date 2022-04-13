using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private float smoothingFactor = 5f;
    private Slider healthBar;
    private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();

        healthBar.maxValue = playerHealth.iniHp;

        Init();
        Game.Instance.OnGame += Init;
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
