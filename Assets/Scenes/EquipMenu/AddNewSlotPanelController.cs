using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNewSlotPanelController : MonoBehaviour
{
    public Text price;
    [HideInInspector]
    public GameObject equipSlotsScrollPanel;
    public void Start()
    {
        //for(int i = 0; i < 4; i++)
        //{
        //    DataController.SetData(FilePath.slotData, equipSlotsScrollPanel.GetComponent<EquipSlotsScrollController>().slotsID, DataType.slotsCount, itemDataValuesCount.slotCount, 0);
        //}
        //GlobalScript.SetValutaValue(ValutaType.Coin, 20000);
            price.text = AddPriceFunction(int.Parse(price.text), equipSlotsScrollPanel.GetComponent<EquipSlotsScrollController>().slots.Count + 1).ToString();
    }
    public void Update()
    {
    }
    public void BuyNewSlot()
    {
        EquipSlotsScrollController EquipController = equipSlotsScrollPanel.GetComponent<EquipSlotsScrollController>();
        print(EquipController.slotsID);
        if (GlobalScript.GetValutaValue(ValutaType.Coin) >= int.Parse(price.text))
        {
            DataController.SetData(FilePath.slotData, EquipController.slotsID, DataType.slotsCount, itemDataValuesCount.slotCount, DataController.GetData(FilePath.slotData, EquipController.slotsID, DataType.slotsCount, itemDataValuesCount.slotCount) + 1);
            print(DataController.GetData(FilePath.slotData, EquipController.slotsID, DataType.slotsCount, itemDataValuesCount.slotCount));
            GlobalScript.SetValutaValue(ValutaType.Coin, GlobalScript.GetValutaValue(ValutaType.Coin) - int.Parse(price.text));
            EquipController.AddSlot();
            price.text = AddPriceFunction(int.Parse(price.text), equipSlotsScrollPanel.GetComponent<EquipSlotsScrollController>().slots.Count + 1).ToString();
            if (EquipController.slots.Count >= EquipController.maxSlots)
            {
                Destroy(gameObject);
            }
            gameObject.transform.SetAsLastSibling();
        }
    }
    public int AddPriceFunction(int price, int k)
    {
        return price * k;
    }
}
