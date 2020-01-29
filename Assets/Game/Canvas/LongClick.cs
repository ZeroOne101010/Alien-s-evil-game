using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LongClick : MonoBehaviour
{
    public bool Down = false;
    public GameObject Person;
    public void Update()
    {
        if (Down == true)
        {
            Person.GetComponent<EntityAttack>().attack(null);
        }
    }
    public void ChangeDownToTrue()
    {
        Down = true;
    }
    public void ChangeDownToFalse()
    {
        Down = false;
    }
}
