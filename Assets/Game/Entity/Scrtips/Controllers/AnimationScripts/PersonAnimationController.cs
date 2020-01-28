using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAnimationController : SimpleAnimationController
{

    public string nameHaveWeapon = "HaveWeapon";
    public string nameTypeWeapon = "TypeWeapon";

    private InventoryWithHand inventoryWithHand;
    private Animator animator;

    public override void controllerStart()
    {
        base.controllerStart();
        inventoryWithHand = GetComponent<InventoryWithHand>();
        animator = GetComponent<Animator>();
    }


    public override void controllerUpdate()
    {
        base.controllerUpdate();
        animator.SetBool(nameHaveWeapon, inventoryWithHand.haveWeapon());
        if (inventoryWithHand.haveWeapon())
        {
            animator.SetInteger(nameTypeWeapon, inventoryWithHand.itemInHand.GetComponent<WeaponController>().typeWeapon);
        }
    }

}
