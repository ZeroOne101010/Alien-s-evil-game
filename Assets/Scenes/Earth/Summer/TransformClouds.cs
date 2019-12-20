using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformClouds : MonoBehaviour
{
    public float speed = 3;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
