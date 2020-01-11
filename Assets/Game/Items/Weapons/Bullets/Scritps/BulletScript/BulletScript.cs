using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletScript : MonoBehaviour
{
    void Start()
    {
        bulletStart();
    }

    void Update()
    {
        bulletUpdate();
    }

    public virtual void bulletStart()
    {

    }

    public virtual void bulletUpdate()
    {

    }

    public virtual void bulletInit()
    {

    }
}
