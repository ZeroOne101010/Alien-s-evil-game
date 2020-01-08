using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITakeAWeapon : AITask
{
    public GameObject gameObject;

    public GameObject weaponSlot1;
    public GameObject weaponSlot2;
    public GameObject keepedWeapon;
   // public RegistoredWeapons registoredWeapons;
    public Vector3 weaponOffset;

    public AITakeAWeapon(GameObject gameObject, GameObject weaponSlot1, GameObject weaponSlot2, Vector3 weaponOffset)
    {
        this.gameObject = gameObject;
        this.weaponSlot1 = weaponSlot1;
        this.weaponSlot2 = weaponSlot2;
        this.weaponOffset = weaponOffset;
        //registoredWeapons = GameObject.FindGameObjectWithTag("WeaponRegistoryManager").GetComponent<RegistoredWeapons>();
    }

    public AITakeAWeapon(GameObject gameObject, GameObject weaponSlot1, GameObject weaponSlot2)
    {
        this.gameObject = gameObject;
        this.weaponSlot1 = weaponSlot1;
        this.weaponSlot2 = weaponSlot2;
        //registoredWeapons = GameObject.FindGameObjectWithTag("WeaponRegistoryManager").GetComponent<RegistoredWeapons>();
    }

    public override void updateTask()
    {
        UpdateChangeSlot(weaponOffset);
        shootWeapon();
    }

    public void UpdateChangeSlot(Vector3 spawnOffset)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(weaponSlot1 != null)
            {
                MonoBehaviour.Destroy(keepedWeapon);
                keepedWeapon = MonoBehaviour.Instantiate(weaponSlot1, gameObject.transform.position + spawnOffset, Quaternion.identity, gameObject.transform);
                keepedWeapon.transform.rotation = gameObject.transform.rotation;
            }
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MonoBehaviour.Destroy(keepedWeapon);
            keepedWeapon = MonoBehaviour.Instantiate(weaponSlot2, gameObject.transform.position + spawnOffset, Quaternion.identity,  gameObject.transform);
            keepedWeapon.transform.rotation = gameObject.transform.rotation;
        }
    }
    public void shootWeapon()
    {
        if (keepedWeapon != null)
            if (keepedWeapon.GetComponent<WeaponWork>() != null)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    //keepedWeapon.GetComponent<WeaponWork>().weaponImplementation(keepedWeapon.GetComponent<WeaponWork>().weaponDamage, keepedWeapon.GetComponent<WeaponWork>().bulletType, keepedWeapon);
                }
            }

    }

}
