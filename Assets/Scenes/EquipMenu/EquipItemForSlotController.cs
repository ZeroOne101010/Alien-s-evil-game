using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItemForSlotController : MonoBehaviour
{
    [HideInInspector]
    public GameObject equipSlotsScroll;
    public GameObject alredyUsedBoard;
    public Color alreadyUsedLight;
    public Color alreadyUsedDark;
    public Color alreadyUsedBlack;
    public GameObject nameBoard;
    public Text slotIdText;
    public Image image;
    public Text nameText;
    [HideInInspector]
    public int slotIDWhichOpenPanel;
    [HideInInspector]
    public int itemID;
    [HideInInspector]
    public bool isEquiped;
    public void SetDataToslotWhichOpenPanel()
    {
        swapReplacedItem();
        ItemDataController.SetItemData(itemID, ItemDataType.isEquiped, slotIDWhichOpenPanel);
    }
    public void swapReplacedItem()
    {
        if (equipSlotsScroll.GetComponent<EquipSlotsScrollController>().slots[slotIDWhichOpenPanel].GetComponent<EquipWeaponSlotController>().itemID != -1)
        {
            ItemDataController.SetItemData(equipSlotsScroll.GetComponent<EquipSlotsScrollController>().slots[slotIDWhichOpenPanel].GetComponent<EquipWeaponSlotController>().itemID, ItemDataType.isEquiped, ItemDataController.GetItemData(itemID, ItemDataType.isEquiped));
        }
    }
}
