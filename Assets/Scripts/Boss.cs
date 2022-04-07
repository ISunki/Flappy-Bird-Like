using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss
{
    [SerializeField] private GameObject missle;

    private Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMissle()
    {
        GameObject.Instantiate(missle, firePoint.position, firePoint.rotation);
    }
    
    
}
