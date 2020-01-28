using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeShot : WeaponShot
{

    public float rangeAttack;
    public float damage;

    public override void startWeaponShot()
    {
        base.startWeaponShot();
    }

    public override void updateWeaponShot()
    {
        base.updateWeaponShot();
    }

}
