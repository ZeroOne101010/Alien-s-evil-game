using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject[] Guns = new GameObject[3];
    Transform FirePoint;
    private void Update()
    {
        
    }
    public void Shot()
    {
         foreach(GameObject element in Guns)
        {
            if (element.active == true)
            {
                FirePoint = GetComponentInChildren<Transform>();
                print(FirePoint.transform.position.x);
                print(FirePoint.transform.position.y);
            }
        }
    }
}