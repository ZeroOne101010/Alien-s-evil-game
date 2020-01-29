using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBoard : MonoBehaviour
{
    public Image image;
    public Text price;
    public ValutaType valutaType;
    public int ItemID;
    public GameObject[] initalBoards;
    public GameObject[] replacementBoards;
    public void Start()
    {
        CheckBoughtItem();
        if(ItemDataController.GetItemData(ItemID, ItemDataType.isBought) == 1)
        {
            SetInitalColor();
        }
    }
    public void Update()
    {
    }
    private void CheckBoughtItem()
    {      
        if (ItemDataController.GetItemData(ItemID, ItemDataType.isBought) == 1)
        {
            GlobalScript.SetObjectsActive(initalBoards, false);
            GlobalScript.SetObjectsActive(replacementBoards, true);
        }
    }
    public void Buy()
    {
        //if (ItemDataController.GetItemData(ItemID, ItemDataType.isBought) == 0)
            if (GlobalScript.GetValutaValue(valutaType) >= int.Parse(price.text))
            {
                GlobalScript.SetValutaValue(valutaType, GlobalScript.GetValutaValue(valutaType) - int.Parse(price.text));
                ItemDataController.SetItemData(ItemID, ItemDataType.isBought, true);
                ItemDataController.SetItemData(ItemID, ItemDataType.isEquiped, -1);
                GlobalScript.SetObjectsActive(initalBoards, false);
                GlobalScript.SetObjectsActive(replacementBoards, true);
            }
    }
    public void SetInitalColor()
    {
        image.color = new Color(255, 255, 255);
    }
}
