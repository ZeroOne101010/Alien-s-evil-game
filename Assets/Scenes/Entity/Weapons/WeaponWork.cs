using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponWork : MonoBehaviour
{
    public WeaponImplementation weaponImplementation;
    public int implementationID;
    public float weaponDamage;
    public GameObject bulletType;
    void Start()
    {
        weaponImplementation = new WeaponImplementation(RegistoredWeapons.weaponImplementation[implementationID]);
    }


    void Update()
    {
        
    }
}
