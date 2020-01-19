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
    public static void SetItemData(int itemID, ItemDataType itemDataType, bool value)
    {
        using (FileStream itemData = new FileStream(@"Reestr\itemData.txt", FileMode.OpenOrCreate))
        {
            byte[] itemDataBin = new byte[1];
            itemData.Seek((itemID * 2) + (long)itemDataType, SeekOrigin.Current);
            itemData.Read(itemDataBin, 0, 1);
            itemData.Seek(-1, SeekOrigin.Current);
            itemData.Write(Encoding.UTF8.GetBytes(value == true ? "1" : "0"), 0, 1);
        }
    }
    public static bool GetItemData(int itemID, ItemDataType itemDataType)
    {
        using (FileStream itemData = new FileStream(@"Reestr\itemData.txt", FileMode.OpenOrCreate))
        {
            byte[] itemDataBin = new byte[1];
            itemData.Seek((itemID * 2) + (long)itemDataType, SeekOrigin.Current);
            itemData.Read(itemDataBin, 0, 1);
            return int.Parse(Encoding.UTF8.GetString(itemDataBin)) == 1 ? true : false;
        }
    }
    public static void ClearAllValues()
    {
        using (FileStream itemData = new FileStream(@"Reestr\itemData.txt", FileMode.OpenOrCreate))
        {
            for (int k = 0; k < itemData.Length; k++)
            {
                itemData.Seek(k * 2, SeekOrigin.Current);
                itemData.Seek(-1, SeekOrigin.Current);
                itemData.Write(Encoding.UTF8.GetBytes("0"), 0, 1);
            }
        }
    }
}
