using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotController : MonoBehaviour
{
    public int ItemID;
    public int SlotID;
    public GameObject chooseWeaponPanel;
    public GameObject scroll;
    public Image image;
    public void TakeWeapon()
    {
        scroll.SetActive(false);
        chooseWeaponPanel.GetComponent<ChooseWeaponController>().selectedWeaponID[chooseWeaponPanel.GetComponent<ChooseWeaponController>().weaponsTypeID] = ItemID;
        chooseWeaponPanel.GetComponent<ChooseWeaponController>().ClearScrollAndSlots();
        chooseWeaponPanel.GetComponent<ChooseWeaponController>().FillSlots();
        ChooseWeaponController chooseWeaponController = chooseWeaponPanel.GetComponent<ChooseWeaponController>();
        chooseWeaponController.person.GetComponent<InventoryUserController>().setItemInHand(chooseWeaponController.weaponsTypes[chooseWeaponController.weaponsTypeID][chooseWeaponController.selectedWeaponID[chooseWeaponController.weaponsTypeID]]);
    }
}
