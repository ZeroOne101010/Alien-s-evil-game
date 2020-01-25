using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public static string coinReestrKey = "Gold";
    public static string equipedWeaponReestrKey = "Weapon";
    public static string equipedColdWeaponReestrKey = "ColdWeapon";
    public static string equipedPistolReestrKey = "Pistol";
    public static string equipedAbilityReestrKey = "Ability";

    public static void SetObjectsActive(GameObject[] boards, bool value)
    {
        for (int i = 0; i < boards.Length; i++)
            boards[i].SetActive(value);
    }
    public static void SetValutaValue(ValutaType valuteType, int value)
    {
        using (FileStream fileStream = new FileStream(@"Reestr\valutaData.txt", FileMode.OpenOrCreate))
        {
            byte[] valutaDataBin = new byte[sizeof(int)];
            valutaDataBin = BitConverter.GetBytes(value);
            fileStream.Seek((int)valuteType * sizeof(int), SeekOrigin.Current);
            fileStream.Write(valutaDataBin, 0, sizeof(int));
        }
    }
    public static int GetValutaValue(ValutaType valuteType)
    {
        using (FileStream fileStream = new FileStream(@"Reestr\valutaData.txt", FileMode.OpenOrCreate))
        {
            fileStream.Seek((int)valuteType * sizeof(int), SeekOrigin.Current);
            byte[] Check = new byte[sizeof(int)];
            fileStream.Read(Check, 0, sizeof(int));
            return BitConverter.ToInt32(Check, 0);
        }
    }
    public static void ActivateSelectedElementFromArray(GameObject[] gameObjects, int selectedElement)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (i == selectedElement)
            {
                gameObjects[i].SetActive(true);
            }
            else
            {
                gameObjects[i].SetActive(false);
            }
        }
    }
}
