using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlotsController : MonoBehaviour
{
    public int slotsID;
    public int maxSlots;
    public SlotType slotsType;
    public GameObject slotPrefab;
    public GameObject addSlotPanelPrefab;
    public GameObject contentObject;
    [HideInInspector]
    public List<GameObject> slots = new List<GameObject>();
    [HideInInspector]
    public GameObject addSlotPanel;
    public void Awake()
    {
    }
    public void Start()
    {
        //DataController.SetData(FilePath.slotData, slotsID, DataType.slotsCount, 2);
        СompareSlotsCount();
    }
    public void Update()
    {
    }
    public void СompareSlotsCount()
    {
        for(int i = 0; i < DataController.GetData(FilePath.slotData, slotsID, DataType.slotsCount); i++)
        {
            AddSlot();
        }
    }
    public void AddSlot()
    {
        Destroy(addSlotPanel);
        slots.Add(Instantiate(slotPrefab, contentObject.transform));
        if (slots.Count < maxSlots)
        {
            addSlotPanel = Instantiate(addSlotPanelPrefab, contentObject.transform);
        }
    }
}
