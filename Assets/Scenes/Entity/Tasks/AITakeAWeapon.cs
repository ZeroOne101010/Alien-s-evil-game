using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITakeAWeapon : MonoBehaviour
{
    public GameObject weaponSlot1;
    public GameObject weaponSlot2;
    public GameObject keepedWeapon;
    public RegistoredWeapons registoredWeapons;
    public Vector3 weaponOffset;
    void Start()
    {
        registoredWeapons = GameObject.FindGameObjectWithTag("WeaponRegistoryManager").GetComponent<RegistoredWeapons>();
    }
    void Update()
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
                Destroy(keepedWeapon);
                keepedWeapon = Instantiate(weaponSlot1, transform.position + spawnOffset, Quaternion.identity, gameObject.transform);
                keepedWeapon.transform.rotation = transform.rotation;
            }
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(keepedWeapon);
            keepedWeapon = Instantiate(weaponSlot2, transform.position + spawnOffset, Quaternion.identity,  gameObject.transform);
            keepedWeapon.transform.rotation = transform.rotation;
        }
    }
    public void shootWeapon()
    {
        if (keepedWeapon != null)
            if (keepedWeapon.GetComponent<WeaponWork>() != null)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    keepedWeapon.GetComponent<WeaponWork>().weaponImplementation(keepedWeapon.GetComponent<WeaponWork>().weaponDamage, keepedWeapon.GetComponent<WeaponWork>().bulletType, keepedWeapon);
                }
            }

    }
}
