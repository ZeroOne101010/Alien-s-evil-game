using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponShot : MonoBehaviour
{
    void Start()
    {
        startWeaponShot();
    }

    void Update()
    {
        updateWeaponShot();
    }

    public virtual void startWeaponShot()
    {

    }

    public virtual void updateWeaponShot()
    {

    }

    public abstract void shot(Vector3 offsetShot);

}
