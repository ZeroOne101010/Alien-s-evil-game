using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformClouds : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * rnd.Next(1,3) * Time.deltaTime);
    }
}
