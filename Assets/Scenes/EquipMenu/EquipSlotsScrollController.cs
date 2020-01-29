using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WeaponType 
{
    mainWeapon = 0,
    coldWeapon = 1,
    pistolWeapon = 2,
    granadaWeapon = 3
}

public class EquipSlotsScrollController : MonoBehaviour
{
    public int slotsID;
    public int maxSlots;
    //public int[] weaponsCanSet;
    public WeaponType weaponType;
    public GameObject chooseItemForSlotPanel;
    public GameObject slotPrefab;
    public GameObject addNewSlotPanelPrefab;
    public GameObject scrollContent;
    //[HideInInspector]
    public GameObject addNewSlotPanel;
    [HideInInspector]
    public GameObject prefabManager;
    public PrefabManagerScript prefabManagerScript;
    [HideInInspector]
    public List<GameObject> slots = new List<GameObject>();
    public void Awake()
    {
        prefabManager = GameObject.FindGameObjectWithTag("PrefabManager");
        prefabManagerScript = prefabManager.GetComponent<PrefabManagerScript>();
    }
    public void Start()
    {
        AddSlotsAndAddNewSlotPanel();
        if (slots.Count < maxSlots)
        {
            addNewSlotPanel = Instantiate(addNewSlotPanelPrefab, scrollContent.transform);
            addNewSlotPanel.GetComponent<AddNewSlotPanelController>().equipSlotsScrollPanel = gameObject;
            addNewSlotPanel.transform.SetAsLastSibling();
        }
    }
    public void Update()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            SetDataToSlot(slots[i], i);
        }
    }

    public void AddSlot()
    {
        slots.Add(Instantiate(slotPrefab, scrollContent.transform));
    }
    public void AddSlotsAndAddNewSlotPanel()
    {
        for(int i = 0; i < DataController.GetData(FilePath.slotData, slotsID, DataType.slotsCount, itemDataValuesCount.slotCount); i++)
        {
            AddSlot();
        }
    }
    public void SetDataToSlot(GameObject slot, int slotID)
    {
        slot.GetComponent<EquipWeaponSlotController>().slotID = slotID;
        slot.GetComponent<EquipWeaponSlotController>().equipSlotsScroll = gameObject;
        slot.GetComponent<EquipWeaponSlotController>().chooseItemForSlotPanel = chooseItemForSlotPanel;
        slot.GetComponent<EquipWeaponSlotController>().prefabManager = prefabManager;
        slot.GetComponent<EquipWeaponSlotController>().slotsInEquipSlotsScroll = slots;
        slot.GetComponent<EquipWeaponSlotController>().weaponType = weaponType;
        int isAlreadyUsedERROR = 0;
        bool findCoincidence = false;
        for (int i = 0; i < prefabManagerScript.types[(int)weaponType].Length; i++)
        {
            
            if(isAlreadyUsedERROR <= 1)
            {
                if (ItemDataController.GetItemData(prefabManagerScript.types[(int)weaponType][i], ItemDataType.isEquiped) == slotID & ItemDataController.GetItemData(prefabManagerScript.types[(int)weaponType][i], ItemDataType.isBought) == 1)
                {
                    slot.GetComponent<EquipWeaponSlotController>().empotyBoard.SetActive(false);
                    slot.GetComponent<EquipWeaponSlotController>().image.SetActive(true);
                    slot.GetComponent<EquipWeaponSlotController>().itemID = prefabManagerScript.types[(int)weaponType][i];
                    slot.GetComponent<EquipWeaponSlotController>().image.GetComponent<Image>().sprite = prefabManager.GetComponent<PrefabManagerScript>().items[prefabManagerScript.types[(int)weaponType][i]].GetComponent<SpriteRenderer>().sprite;
                    slot.GetComponent<EquipWeaponSlotController>().nameText.text = prefabManager.GetComponent<PrefabManagerScript>().items[prefabManagerScript.types[(int)weaponType][i]].name;
                    findCoincidence = true;
                    isAlreadyUsedERROR++;
                }
            }
            else
            {
                Debug.LogError("Несколько из выбранных оружий для слотов имеют одинаковую переменную ItemDataType.isEquiped = " + slotID);
            }
        }
        if(findCoincidence == false)
        {
            slot.GetComponent<EquipWeaponSlotController>().empotyBoard.SetActive(true);
            slot.GetComponent<EquipWeaponSlotController>().image.SetActive(false);
            slot.GetComponent<EquipWeaponSlotController>().itemID = -1;
        }
    }


}
