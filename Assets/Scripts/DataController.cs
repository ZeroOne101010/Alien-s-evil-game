using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public enum DataType
{
    isBought = 0,
    isEquiped = 1,
    slotsCount = 0,
    slotType = 1,
}
public enum SlotType
{
    mainWeapon = 0,
    coldWeapon = 1,
    pistolWeapon = 2,
    granadaWeapon = 3
}
public enum itemDataValuesCount
{
    slotCount = 2
}
public class DataController : MonoBehaviour
{

    //static int itemDataValuesCount = 2;
    static int encodingOffset = 224;
    public static void SetData(string path, int ID, DataType dataType, itemDataValuesCount itemDataValuesCount, bool value)
    {
        using (FileStream itemData = new FileStream(path, FileMode.OpenOrCreate))
        {
            byte[] itemDataBin = new byte[sizeof(int)];
            itemData.Seek((ID * (int)itemDataValuesCount) + (long)dataType, SeekOrigin.Current);
            itemData.Write(BitConverter.GetBytes((value == true ? 1 + encodingOffset : encodingOffset)), 0, 1);
        }
    }
    public static void SetData(string path, int ID, DataType dataType, itemDataValuesCount itemDataValuesCount, int value)
    {
        using (FileStream itemData = new FileStream(path, FileMode.OpenOrCreate))
        {
            byte[] itemDataBin = new byte[sizeof(int)];
            itemData.Seek((ID * (int)itemDataValuesCount) + (long)dataType, SeekOrigin.Current);
            itemData.Write(BitConverter.GetBytes(value + encodingOffset), 0, 1);
        }
    }
    public static int GetData(string path, int ID, DataType dataType, itemDataValuesCount itemDataValuesCount)
    {
        using (FileStream itemData = new FileStream(path, FileMode.OpenOrCreate))
        {
            byte[] itemDataBin = new byte[sizeof(int)];
            itemData.Seek((ID * (int)itemDataValuesCount) + (long)dataType, SeekOrigin.Current);
            itemData.Read(itemDataBin, 0, 1);
            return BitConverter.ToInt32(itemDataBin, 0) - encodingOffset;
        }
    }
    //public static void SetAllValues(string path, bool value, DataType dataType)
    //{
    //    for (int c = 0; c < PrefabManagerScript.itemsCount; c++)
    //    {
    //        SetData(path, c, dataType, value);
    //    }
    //}
}
