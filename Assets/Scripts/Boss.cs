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
    [SerializeField] private float moveSpeed = 0.5f;
        
    private Transform target;
    private Animator animator;
    private Score score;

    void Start()
    {
        OnStart();
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        score = FindObjectOfType<Score>();
        game = GameObject.FindObjectOfType<Game>().GetComponent<Game>();
        StartGame();
    }

    protected override void OnUpdate()
    {
        Vector3 dir = (target.transform.position - gun.position).normalized;
        gun.rotation = Quaternion.FromToRotation(Vector3.left, dir);
    }

    void StartGame()
    {
        StartCoroutine(StartMove());
    }

    IEnumerator StartMove()
    {
        transform.localPosition = new Vector3(3, 0, 10);
        yield return MoveTo(new Vector3(0.9f, 0, 10));
        yield return new WaitForSeconds(3f);
        yield return MoveTo(new Vector3(0.9f, 0.5f, 10));
        animator.SetTrigger("fire");
        yield return new WaitForSeconds(3f);
        yield return MoveTo(new Vector3(0.9f, -0.5f, 10));
        yield return new WaitForSeconds(3f);
        yield return MoveTo(new Vector3(0.9f, 0.5f, 10));
        yield return new WaitForSeconds(3f);
        yield return MoveTo(new Vector3(0.9f, -0.5f, 10));
        yield return new WaitForSeconds(3f);
        yield return MoveTo(new Vector3(0.9f, 0.5f, 10));
        yield return new WaitForSeconds(3f);
        yield return MoveTo(new Vector3(0.9f, -0.5f, 10));
        yield return new WaitForSeconds(3f);
        yield return MoveTo(new Vector3(0.9f, 0.5f, 10));
        yield return new WaitForSeconds(3f);
        yield return MoveTo(new Vector3(0.9f, -0.5f, 10));
        yield return new WaitForSeconds(3f);
        yield return MoveTo(new Vector3(0.9f, 0.5f, 10));
    }

    IEnumerator MoveTo(Vector3 targetPos)
    {
        while (Vector3.Distance(transform.localPosition, targetPos) > 0.01f)
        {
            Vector3 dir = (targetPos - transform.localPosition).normalized;
            transform.position += dir * Time.deltaTime * moveSpeed; 
            yield return null;
        }
    }

    void GenerateMissle()
    {
        GameObject ins = Instantiate(missle, misslePoint.position, misslePoint.rotation);
        ins.transform.SetParent(transform.parent);
    }

    protected override void Die()
    {
        score.AddScore(10);
        Destroy(gameObject);
    }

}
