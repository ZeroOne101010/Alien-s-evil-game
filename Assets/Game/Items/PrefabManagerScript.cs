using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManagerScript : MonoBehaviour
{
    public GameObject[] items;
    public int typesCount;
    public int[] MainWeaponsCanBeInSlots;
    public int[] ColdWeaponsCanBeInSlots;
    public int[] PistolWeaponsCanBeInSlots;
    public int[] GranadaWeaponsCanBeInSlots;
    public static int itemsCount;
    void Awake()
    {
        itemsCount = items.Length;
    }


    void Update()
    {
        
    }
}
