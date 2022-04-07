using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Boss : Enemy
{
    [SerializeField] private GameObject missle;
    [SerializeField] private Transform misslePoint;
    [SerializeField] private Transform gun;

    private Transform target;
    // Start is called before the first frame update

    new void Start()
    {
        OnStart();
        target = GameObject.FindWithTag("Player").transform;
        Debug.Log("boss onstart");
    }

    protected override void OnUpdate()
    {
        Vector3 dir = (target.transform.position - gun.position).normalized;
        gun.rotation = Quaternion.FromToRotation(Vector3.left, dir);
    }
    
    void GenerateMissle()
    {
        GameObject.Instantiate(missle, misslePoint.position, misslePoint.rotation);
    }

}
