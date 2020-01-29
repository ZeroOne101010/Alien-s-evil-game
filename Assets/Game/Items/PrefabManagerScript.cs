using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManagerScript : MonoBehaviour
{
    public GameObject[] items;
    public int typesCount;
    public int[][] types;
    public int[] MainWeaponsCanBeInSlots;
    public int[] ColdWeaponsCanBeInSlots;
    public int[] PistolWeaponsCanBeInSlots;
    public int[] GranadaWeaponsCanBeInSlots;
    public static int itemsCount;
    void Awake()
    {
        itemsCount = items.Length;
        types = new int[4][];
        types[0] = MainWeaponsCanBeInSlots;
        types[1] = ColdWeaponsCanBeInSlots;
        types[2] = PistolWeaponsCanBeInSlots;
        types[3] = GranadaWeaponsCanBeInSlots;
    }


    void Update()
    {
        
    }
}
