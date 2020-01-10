using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformClouds : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public Vector2 direction;

    void Start()
    {
        Destroy(gameObject, 30);
    }

    void Update()
    {
        Swimming();
    }

    void Swimming()
    {
        transform.Translate(direction * rnd.Next(1, 3) * Time.deltaTime);
    }
}
