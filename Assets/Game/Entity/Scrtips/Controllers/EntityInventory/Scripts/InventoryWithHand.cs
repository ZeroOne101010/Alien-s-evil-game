using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryWithHand : InventoryController
{

    public GameObject itemInHand;

    public override void controllerUpdate()
    {
        base.controllerUpdate();
    }

    public GameObject getItemInHand(int handIdInInventory)
    {
        if(inventory.item.Count > 0)
        {
            return inventory.item[handIdInInventory];
        }
        else
        {
            return null;
    }
        }

    public void setItemInHand(int handIdInInventory)
    {
        if (handIdInInventory < inventory.item.Count)
        {
            GameObject item = getItemInHand(handIdInInventory);
            if (item != itemInHand)
            {
                WeaponController weaponController = item.GetComponent<WeaponController>();
                if (weaponController != null)
                {
                    toParentItemToHand(item);
                }
            }
            else
            {
                ParentOutItemInHand();
            }
        }
    }

    public void toParentItemToHand(GameObject item)
    {
        ParentOutItemInHand();
        WeaponController weaponController = item.GetComponent<WeaponController>();
        if (weaponController != null)
        {
            itemInHand = item;
            GameObject hands = gameObject.transform.Find("Hands").gameObject;
            itemInHand.transform.position = hands.transform.position;
            itemInHand.transform.parent = hands.transform;
            weaponController.canTakeItem = false;
            Rigidbody2D rigid = itemInHand.GetComponent<Rigidbody2D>();
            if (rigid != null)
            {
                rigid.simulated = false;
            }

            itemInHand.transform.rotation = transform.rotation;

            EntityAnimation entityAnimation = GetComponent<EntityAnimation>();

            itemInHand.SetActive(true);
        }
    }

    public void ParentOutItemInHand()
    {
        if (itemInHand != null)
        {
            itemInHand.SetActive(false);
            Rigidbody2D rigid = itemInHand.GetComponent<Rigidbody2D>();
            if(rigid != null)
            {
                rigid.simulated = true;
            }
            WeaponController weaponController = itemInHand.GetComponent<WeaponController>();
            itemInHand.transform.parent = null;
            weaponController.canTakeItem = true;
            itemInHand = null;
            EntityAnimation entityAnimation = GetComponent<EntityAnimation>();
        }
    }

    public bool haveWeapon()
    {
        return itemInHand == null ? false : true;
    }
}
