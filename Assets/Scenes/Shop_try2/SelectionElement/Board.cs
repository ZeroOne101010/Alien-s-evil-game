using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Board : MonoBehaviour
{
    void Start()
    {
        BoardStart();
    }

    void Update()
    {
        BoardUpdate();
    }
    public virtual void BoardStart()
    {

    }
    public virtual void BoardUpdate()
    {

    }
}
