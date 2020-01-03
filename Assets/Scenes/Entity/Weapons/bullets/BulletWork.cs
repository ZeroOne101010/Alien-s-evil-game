using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWork : MonoBehaviour
{
    public BulletImplementation bulletImplementation;
    public int implementationID;
    [HideInInspector]
    public float damage;
    [HideInInspector]
    public Vector2 diraction;
    void Start()
    {
        bulletImplementation = new BulletImplementation(RegisteredBullets.bulletImplementation[implementationID]);
    }
    void Update()
    {
       bulletImplementation(damage, diraction, gameObject);
    }
}
