using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipWeaponSlotController : MonoBehaviour
{
    public GameObject image;
    public Text nameText;
    public GameObject empotyBoard;
    [HideInInspector]
    public WeaponType weaponType;
    [HideInInspector]
    public List<GameObject> slotsInEquipSlotsScroll;
    [HideInInspector]
    public int slotID;
    [HideInInspector]
    public int itemID;
    [HideInInspector]
    public GameObject equipSlotsScroll;
    [HideInInspector]
    public GameObject chooseItemForSlotPanel;
    [HideInInspector]
    public GameObject prefabManager;
    public void OpenChooseWeaponForSlotPanel()
    {
        chooseItemForSlotPanel.SetActive(true);
        chooseItemForSlotPanel.GetComponent<ChooseItemForSlotController>().chooseItemForSlotScroll.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
        chooseItemForSlotPanel.GetComponent<ChooseItemForSlotController>().equipSlotsScroll = equipSlotsScroll;
        chooseItemForSlotPanel.GetComponent<ChooseItemForSlotController>().prefabManager = prefabManager;
        chooseItemForSlotPanel.GetComponent<ChooseItemForSlotController>().slotsInEquipSlotsScroll = slotsInEquipSlotsScroll;
        chooseItemForSlotPanel.GetComponent<ChooseItemForSlotController>().slotIDWhichOpenPanel = slotID;
        chooseItemForSlotPanel.GetComponent<ChooseItemForSlotController>().weaponType = weaponType;
        chooseItemForSlotPanel.GetComponent<ChooseItemForSlotController>().FillContent();

    }
}
