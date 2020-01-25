using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManagerScript : MonoBehaviour
{
    public GameObject[] items;
    public static int itemsCount;
    void Awake()
    {
        itemsCount = items.Length;

    }


    void Update()
    {
        
    }
}
