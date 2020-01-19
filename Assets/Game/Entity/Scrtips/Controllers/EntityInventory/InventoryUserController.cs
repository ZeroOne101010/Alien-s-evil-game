using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUserController : InventoryWithHand
{

    public override void controllerStart()
    {
        base.controllerStart();
    }

    public override void controllerUpdate()
    {
        dropLastItem();
        takeItemInHand();
        base.controllerUpdate();
    }

    public void takeItemInHand()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            setItemInHand(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            setItemInHand(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            setItemInHand(2);
        }
    }

    public void dropLastItem()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject lastItem = inventory.getLastItem();
            if (lastItem != null && lastItem != itemInHand)
            {
                inventory.dropLastItem();
            }
            else
            {
                ParentOutItemInHand();
                inventory.dropLastItem();
            }
        }
    }

}
