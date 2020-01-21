using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBoard : Board
{
    public GameObject button;
    public Text price;
    public GameObject[] initalBoards;
    public GameObject[] replacementBoards;
    private ElementController elementController;
    public override void BoardStart()
    {
        base.BoardStart();
        elementController = GetComponent<ElementController>();
        CheckBoughtItem();
        GlobalScript.SetValutaValue(elementController.valutaType, 2500);
        //ItemDataController.ClearAllValues();
    }
    public override void BoardUpdate()
    {
        base.BoardUpdate();
    }
    private void CheckBoughtItem()
    {
        if (ItemDataController.GetItemData(GetComponent<ElementController>().itemID, ItemDataType.isBought) == true)
        {
            GlobalScript.SetObjectsActive(initalBoards, false);
            GlobalScript.SetObjectsActive(replacementBoards, true);
        }
    }
    public void Buy()
    {
        if (ItemDataController.GetItemData(GetComponent<ElementController>().itemID, ItemDataType.isBought) == false)
            if (GlobalScript.GetValutaValue(elementController.valutaType) >= int.Parse(price.text))
            {
                GlobalScript.SetValutaValue(elementController.valutaType, GlobalScript.GetValutaValue(elementController.valutaType) - int.Parse(price.text));
                ItemDataController.SetItemData(elementController.itemID, ItemDataType.isBought, true);
                GlobalScript.SetObjectsActive(initalBoards, false);
                GlobalScript.SetObjectsActive(replacementBoards, true);
            }
    }
}
