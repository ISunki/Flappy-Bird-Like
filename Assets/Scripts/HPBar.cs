using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    private float width;

    private RectTransform barRect;
    // Start is called before the first frame update
    void Start()
    {
        barRect = GetComponent<RectTransform>();
        width = barRect.sizeDelta.x;
    }
    
    public void UpdateUI(Health health)
    {
        float widthValue = (health.hp / health.iniHp) * width;
        barRect.sizeDelta = new Vector2(widthValue, barRect.sizeDelta.y);
    }
}
