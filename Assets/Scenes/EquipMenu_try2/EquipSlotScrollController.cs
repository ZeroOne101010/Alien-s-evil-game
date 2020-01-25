using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlotScrollController : MonoBehaviour
{
    public GameObject[] weapons;
    void Start()
    {
    }

    void Update()
    {
        UpdateChooseWeapon();
    }
    public void UpdateChooseWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {          
            if (ItemDataController.GetItemData(weapons[i].GetComponent<EquipWeaponInSlotController>().itemID, ItemDataType.isBought) == 1)
            {
                weapons[i].SetActive(true);
            }
        }
    }
}
