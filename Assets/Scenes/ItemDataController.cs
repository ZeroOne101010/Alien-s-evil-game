using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
public enum ItemDataType
{
    isBought = 0,
    isEquiped = 1
}
public class ItemDataController : MonoBehaviour
{
    static int itemDataValuesCount = 2;
    static int encodingOffset = 224;
    public static void SetItemData(int itemID, ItemDataType itemDataType, bool value)
    {
        using (FileStream itemData = new FileStream(@"Reestr\itemData.txt", FileMode.OpenOrCreate))
        {
            byte[] itemDataBin = new byte[sizeof(int)];
            itemData.Seek((itemID * itemDataValuesCount) + (long)itemDataType, SeekOrigin.Current);
            itemData.Write(BitConverter.GetBytes((value == true ? 1 + encodingOffset : encodingOffset)), 0, 1);
        }
    }
    public static void SetItemData(int itemID, ItemDataType itemDataType, int slot)
    {
        print("k");
        using (FileStream itemData = new FileStream(@"Reestr\itemData.txt", FileMode.OpenOrCreate))
        {
            byte[] itemDataBin = new byte[sizeof(int)];
            itemData.Seek((itemID * itemDataValuesCount) + (long)itemDataType, SeekOrigin.Current);
            itemData.Write(BitConverter.GetBytes(slot + encodingOffset), 0, 1);
        }
    }
    //public static bool GetItemData(int itemID, ItemDataType itemDataType)
    //{
    //    using (FileStream itemData = new FileStream(@"Reestr\itemData.txt", FileMode.OpenOrCreate))
    //    {
    //        byte[] itemDataBin = new byte[sizeof(int)];
    //        itemData.Seek((itemID * itemDataValuesCount) + (long)itemDataType, SeekOrigin.Current);
    //        itemData.Read(itemDataBin, 0, 1);
    //        return BitConverter.ToInt32(itemDataBin, 0) == encodingOffset ? true : false;
    //    }
    //}
    public static int GetItemData(int itemID, ItemDataType itemDataType)
    {
        using (FileStream itemData = new FileStream(@"Reestr\itemData.txt", FileMode.OpenOrCreate))
        {
            byte[] itemDataBin = new byte[sizeof(int)];
            itemData.Seek((itemID * itemDataValuesCount) + (long)itemDataType, SeekOrigin.Current);
            itemData.Read(itemDataBin, 0, 1);
            return BitConverter.ToInt32(itemDataBin, 0) - encodingOffset;
        }
    }
    public static void SetAllValues(bool value, ItemDataType itemDataType)
    {
        for (int c = 0; c < PrefabManagerScript.itemsCount; c++)
        {
            SetItemData(c, itemDataType, value);
        }
    }
}
