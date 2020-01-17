using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThoughtTime : MonoBehaviour
{

    public float time;
    private float timer;

    void Start()
    {
        timer = time;
    }

    void Update()
    {
        timer--;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
