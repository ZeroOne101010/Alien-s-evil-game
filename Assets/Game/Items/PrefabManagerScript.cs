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
        DataController.SetData(FilePath.slotData, 0, DataType.slotsCount, itemDataValuesCount.slotCount, 1);
        DataController.SetData(FilePath.slotData, 1, DataType.slotsCount, itemDataValuesCount.slotCount, 1);
        DataController.SetData(FilePath.slotData, 2, DataType.slotsCount, itemDataValuesCount.slotCount, 1);
        DataController.SetData(FilePath.slotData, 3, DataType.slotsCount, itemDataValuesCount.slotCount, 1);
    }


    void Update()
    {
        
    }
}
