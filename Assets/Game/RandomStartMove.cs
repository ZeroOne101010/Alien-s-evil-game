using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartMove : MonoBehaviour
{

    public float minSpeedMove;
    public float maxSpeedMove;

    void Start()
    {
        float t = Random.Range(0, Mathf.PI * 2);
        Vector2 direction = new Vector2(Mathf.Cos(t), Mathf.Sin(t));
        GetComponent<Rigidbody2D>().velocity = direction * Random.Range(minSpeedMove, maxSpeedMove);
    }


    void Update()
    {
        
    }
}
