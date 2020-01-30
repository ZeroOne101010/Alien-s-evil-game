using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWeaponController : MonoBehaviour
{
    public Image image;
    public int weaponsTypeID;
    public GameObject slotPrefab;
    public GameObject scrollContent;
    public GameObject scroll;
    [HideInInspector]
    public int[] selectedWeaponID;
    [HideInInspector]
    public int[][] weaponsTypes;
    [HideInInspector]
    public List<GameObject> slots = new List<GameObject>();
    [HideInInspector]
    public GameObject PrefabManager;
    public GameObject person;
    public List<GameObject> weapons = new List<GameObject>();
    public void Awake()
    {
        //ItemDataController.SetAllValues(-1, ItemDataType.isEquiped);
        //ItemDataController.SetAllValues(-1, ItemDataType.isBought);
        PrefabManager = GameObject.FindGameObjectWithTag("PrefabManager");
        //print(PrefabManager.GetComponent<PrefabManagerScript>().typesCount);
        selectedWeaponID = new int[PrefabManager.GetComponent<PrefabManagerScript>().typesCount];
        weaponsTypes = new int[PrefabManager.GetComponent<PrefabManagerScript>().typesCount][];

        weaponsTypes[0] = PrefabManager.GetComponent<PrefabManagerScript>().MainWeaponsCanBeInSlots;
        weaponsTypes[1] = PrefabManager.GetComponent<PrefabManagerScript>().ColdWeaponsCanBeInSlots;
        weaponsTypes[2] = PrefabManager.GetComponent<PrefabManagerScript>().PistolWeaponsCanBeInSlots;
        weaponsTypes[3] = PrefabManager.GetComponent<PrefabManagerScript>().GranadaWeaponsCanBeInSlots;
  
    }
    public void Start()
    {
        FillSlots();
        for (int i = 0; i < PrefabManager.GetComponent<PrefabManagerScript>().items.Length; i++)
        {
            weapons.Add(Instantiate(PrefabManager.GetComponent<PrefabManagerScript>().items[i], new Vector2(0, 0), Quaternion.identity));
            weapons[weapons.Count - 1].SetActive(false);
            Inventory inventory = person.GetComponent<Inventory>();
            inventory.addItem(weapons[weapons.Count - 1]);
            weapons[weapons.Count - 1].GetComponent<WeaponController>().takeTheWeapon(person);
        }
    }
    public void Update()
    {
        image.sprite = PrefabManager.GetComponent<PrefabManagerScript>().items[weaponsTypes[weaponsTypeID][selectedWeaponID[weaponsTypeID]]].GetComponent<SpriteRenderer>().sprite;
    }
    public void ClearScrollAndSlots()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            Destroy(slots[i]);
        }
        slots.Clear();
    }
    public void FillSlots()
    {
        for (int itemsCount = 0; itemsCount < weaponsTypes[weaponsTypeID].Length; itemsCount++)
        {
            if (ItemDataController.GetItemData(weaponsTypes[weaponsTypeID][itemsCount], ItemDataType.isEquiped) > -1 & weaponsTypes[weaponsTypeID][itemsCount] != weaponsTypes[weaponsTypeID][selectedWeaponID[weaponsTypeID]])
            {
                slots.Add(Instantiate(slotPrefab, scrollContent.transform));
                slots[slots.Count - 1].GetComponent<WeaponSlotController>().ItemID = weaponsTypes[weaponsTypeID][itemsCount];
                slots[slots.Count - 1].GetComponent<WeaponSlotController>().SlotID = slots.Count - 1;
                slots[slots.Count - 1].GetComponent<WeaponSlotController>().scroll = scroll;
                slots[slots.Count - 1].GetComponent<WeaponSlotController>().chooseWeaponPanel = gameObject;
                slots[slots.Count - 1].GetComponent<WeaponSlotController>().image.sprite = PrefabManager.GetComponent<PrefabManagerScript>().items[weaponsTypes[weaponsTypeID][itemsCount]].GetComponent<SpriteRenderer>().sprite;
            }
        }
    }
    public void CloseOpenScrollPanel()
    {
        scroll.SetActive(!scroll.active);
        scroll.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
    }
}
