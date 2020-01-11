using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorInStart : MonoBehaviour
{

    public Color[] color;

    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        int id = Random.Range(0, color.Length);
        renderer.color = color[id];
    }


    void Update()
    {
        
    }
}
