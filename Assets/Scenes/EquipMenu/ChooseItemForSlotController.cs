using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseItemForSlotController : MonoBehaviour
{
    public GameObject scrollContent;
    public GameObject EquipItemForSlotPrefab;
    [HideInInspector]
    public int slotIDWhichOpenPanel;
    [HideInInspector]
    public List<GameObject> slotsInEquipSlotsScroll; 
    [HideInInspector]
    public List<GameObject> itemsForSlots = new List<GameObject>();
    [HideInInspector]
    public GameObject equipSlotsScroll;
    [HideInInspector]
    public GameObject prefabManager;
    public void Start()
    {
        //ItemDataController.SetAllValues(-1, ItemDataType.isEquiped);
        //ItemDataController.SetAllValues(-1, ItemDataType.isBought);
    }
    public void Update()
    {
    }
    public void AddEquipItemForSlot(int itemID)
    {
        itemsForSlots.Add(Instantiate(EquipItemForSlotPrefab, scrollContent.transform));
        itemsForSlots[itemsForSlots.Count - 1].GetComponent<EquipItemForSlotController>().itemID = itemID;
        itemsForSlots[itemsForSlots.Count - 1].GetComponent<EquipItemForSlotController>().slotIDWhichOpenPanel = slotIDWhichOpenPanel;
        itemsForSlots[itemsForSlots.Count - 1].GetComponent<EquipItemForSlotController>().equipSlotsScroll = equipSlotsScroll;
        CheckUsedAlreadySlot(itemID);
    }
    public void CheckUsedAlreadySlot(int itemID)
    {
        //DeactivateAlredyEqupedTag(itemsForSlots[itemsForSlots.Count - 1]);
        for (int i = 0; i < equipSlotsScroll.GetComponent<EquipSlotsScrollController>().slots.Count; i++)
        {
            if (itemID == equipSlotsScroll.GetComponent<EquipSlotsScrollController>().slots[i].GetComponent<EquipWeaponSlotController>().itemID)
            {
                print("LOL");
                ActivateAlredyEqupedTag(itemsForSlots[itemsForSlots.Count - 1], i);
            }

        }
    }
    public void FillContent()
    {
        for(int i = 0; i < equipSlotsScroll.GetComponent<EquipSlotsScrollController>().weaponsCanSet.Length; i++)
        {
            if (ItemDataController.GetItemData(equipSlotsScroll.GetComponent<EquipSlotsScrollController>().weaponsCanSet[i], ItemDataType.isBought) > 0)
            {
                AddEquipItemForSlot(equipSlotsScroll.GetComponent<EquipSlotsScrollController>().weaponsCanSet[i]);
                itemsForSlots[itemsForSlots.Count - 1].GetComponent<Button>().onClick.AddListener(ClosePanelAndSetDataToSlot);
                SetDataToEquipItemForSlot(itemsForSlots[itemsForSlots.Count - 1]);
            }
        }
    }
    public void SetDataToEquipItemForSlot(GameObject EquipItemForSlot)
    {
        EquipItemForSlot.GetComponent<EquipItemForSlotController>().image.sprite = prefabManager.GetComponent<PrefabManagerScript>().items[EquipItemForSlot.GetComponent<EquipItemForSlotController>().itemID].GetComponent<SpriteRenderer>().sprite;
        EquipItemForSlot.GetComponent<EquipItemForSlotController>().nameText.text = prefabManager.GetComponent<PrefabManagerScript>().items[EquipItemForSlot.GetComponent<EquipItemForSlotController>().itemID].name;
    }
    public void RemoveAllEquipItemForSlot()
    {
        for(int i = 0; i < itemsForSlots.Count; i++)
        {
            Destroy(itemsForSlots[i]);
        }
        itemsForSlots.Clear();
    }
    public void CloseChooseItemForSlotPanel()
    {
        gameObject.SetActive(false);
    }
    public void ActivateAlredyEqupedTag(GameObject itemForSlot, int itemID)
    {
        itemForSlot.GetComponent<EquipItemForSlotController>().alredyUsedBoard.SetActive(true);
        itemForSlot.GetComponent<EquipItemForSlotController>().GetComponent<Image>().color = itemForSlot.GetComponent<EquipItemForSlotController>().alreadyUsedDark;
        itemForSlot.GetComponent<EquipItemForSlotController>().nameBoard.GetComponent<Image>().color = itemForSlot.GetComponent<EquipItemForSlotController>().alreadyUsedLight;
        itemForSlot.GetComponent<EquipItemForSlotController>().nameText.color = itemForSlot.GetComponent<EquipItemForSlotController>().alreadyUsedBlack;
        itemForSlot.GetComponent<EquipItemForSlotController>().slotIdText.text = (itemID + 1).ToString();
    }
    public void DeactivateAlredyEqupedTag(GameObject itemForSlot)
    {
        itemForSlot.GetComponent<EquipItemForSlotController>().alredyUsedBoard.SetActive(false);
        itemForSlot.GetComponent<EquipItemForSlotController>().slotIdText.text = (-1).ToString();
    }
    public void ClosePanelAndSetDataToSlot()
    {
        RemoveAllEquipItemForSlot();
        CloseChooseItemForSlotPanel();
    }

}
