using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonWeaponAttack : EntityAttack
{

    private InventoryWithHand inventoryWithHand;

    public override void attackStart()
    {
        base.attackStart();
        inventoryWithHand = GetComponent<InventoryWithHand>();
    }

    public override void attackUpdate()
    {
        base.attackUpdate();
    }

    public override void attack(GameObject entity)
    {
        base.attack(entity);
        useItemInHand();
    }

    public void useItemInHand()
    {
        if (inventoryWithHand.itemInHand != null)
        {
            WeaponController weaponController = inventoryWithHand.itemInHand.GetComponent<WeaponController>();
            weaponController.shot();
        }
    }
}
