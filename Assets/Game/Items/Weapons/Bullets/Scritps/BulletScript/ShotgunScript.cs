using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    
    void Start()
    {
        SpawnFourBullets();
    }

    void Update()
    {
        
    }
    
    void SpawnFourBullets()
    {
        for(int i = 0; i < 4; i++)
        {
            Instantiate(gameObject,transform.parent);
        }
    }
}
