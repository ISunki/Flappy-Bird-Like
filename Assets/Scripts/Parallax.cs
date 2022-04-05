using System;
using UnityEngine;


public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform subject;
    private float length;
    private float startPos;
    private Vector2 startPosition;

    private Vector2 Travel => (Vector2)cam.transform.position - startPosition;

    private float DistanceFromSubject => transform.position.z - subject.position.z;

    private float ClippingPlane =>
        cam.transform.position.z + 
        (DistanceFromSubject > 0 ? cam.GetComponent<UnityEngine.Camera>().farClipPlane 
            : cam.GetComponent<UnityEngine.Camera>().nearClipPlane);

    private float ParallaxFactor => Mathf.Abs(DistanceFromSubject) / ClippingPlane;


    private void Start()
    {
        startPosition = transform.position;
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - ParallaxFactor));
        float distance = (cam.transform.position.x * ParallaxFactor);
        
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
        
    }
}
