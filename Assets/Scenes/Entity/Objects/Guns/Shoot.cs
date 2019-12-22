using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject[] Guns = new GameObject[3];
    FirePoint FirePoint;
    private void Update()
    {
        
    }
    public void Shot()
    {
         foreach(GameObject element in Guns)
        {
            if (element.active == true)
            {
                    FirePoint = element.GetComponentInChildren<FirePoint>();
                    FirePoint.Shoot();
            }
        }
    }
}