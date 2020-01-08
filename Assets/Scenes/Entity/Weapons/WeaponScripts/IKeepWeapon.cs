using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKeepWeapon
{
    GameObject getCarrierWeapon();

    GameObject getWeapon();
    Vector2 getWeaponOffsetPosition();
    bool addWeapon(Weapon weapon);
    bool removeWeapon(Weapon weapon);

    void dropWeapon(Weapon weapon);
    void dropLastWeapon();
    void dropFristWeapon();
    Weapon getWeaponInHand();
}
