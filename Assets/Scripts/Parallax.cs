using System;
using UnityEngine;


public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform subject;
    
    private Vector2 startPosition;
    private float startZ;

    private Vector2 Travel => (Vector2)camera.transform.position - startPosition;

    private float DistanceFromSubject => transform.position.z - subject.position.z;

    private float ClippingPlane =>
        camera.transform.position.z + 
        (DistanceFromSubject > 0 ? camera.farClipPlane : camera.nearClipPlane);

    private float ParallaxFactor => Mathf.Abs(DistanceFromSubject) / ClippingPlane;


    private void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    private void Update()
    {
        Vector2 newPos = startPosition + Travel * ParallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}
