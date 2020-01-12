using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour
{
    public ItemType itemType;
    [Header("Общие переменные")]
    private GameObject item;
    public Text itemName;
    public Image itemImage;
    public int weaponID;
    private GameObject weaponsIDsManager;
    [HideInInspector]
    public Specifications specifications;

    void Start()
    {
        InitVariables();
        FillFields();
    }

    void Update()
    {
        TakedWeapon();
    }
    public void InitVariables()
    {
        weaponsIDsManager = GameObject.FindGameObjectWithTag("WeaponsID");
        TakedWeapon();
        specifications = item.GetComponent<Specifications>();
    }
    public void FillFields()
    {
        itemName.text = specifications.Name;
        itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        itemImage.preserveAspect = true;
    }
    public void TakedWeapon()
    {
        switch (itemType)
        {
            case ItemType.weapon:
                weaponID = PlayerPrefs.GetInt(GlobalScript.equipedWeaponReestrKey);
                break;
            case ItemType.coldWeapon:
                weaponID = PlayerPrefs.GetInt(GlobalScript.equipedColdWeaponReestrKey);
                break;
            case ItemType.pistolWeapon:
                weaponID = PlayerPrefs.GetInt(GlobalScript.equipedPistolReestrKey);
                break;
            case ItemType.ability:
                weaponID = PlayerPrefs.GetInt(GlobalScript.equipedAbilityReestrKey);
                break;
        }
        item = weaponsIDsManager.GetComponent<WeaponIDs>().weaponsID[weaponID];
    }

}
