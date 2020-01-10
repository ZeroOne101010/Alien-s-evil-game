using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpecifications : MonoBehaviour
{
    public float weaponDamage;
    public float weaponAttackSpeed;
    public void Start()
    {
        if (PlayerPrefs.GetInt(GetComponent<Specifications>().reestrKey) != 0)
        {
            weaponDamage *= PlayerPrefs.GetInt(GetComponent<Specifications>().reestrKey);
            weaponAttackSpeed *= PlayerPrefs.GetInt(GetComponent<Specifications>().reestrKey);
        }
        else
            PlayerPrefs.SetInt(GetComponent<Specifications>().reestrKey, 1);
    }
}
