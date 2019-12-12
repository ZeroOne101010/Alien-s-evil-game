﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIDropObject : MonoBehaviour
{

    public GameObject prifab;
    public Vector2 pos;
    public Quaternion qu;
    public Vector2 direction;
    public float speed;


    public void dropObject()
    {  
        Vector2 force = direction * speed;
        GameObject obj = MonoBehaviour.Instantiate(prifab, pos, qu);
        if (obj.GetComponent<Rigidbody2D>())
        {
            obj.GetComponent<Rigidbody2D>().velocity = force;
        }
    }

}
