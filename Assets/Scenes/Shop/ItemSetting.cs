using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSetting : MonoBehaviour
{
    public GameObject weapon;
    public Text itemName;
    public Text itemDamage;
    public Text itemAttackSpeed;
    public Text itemDescription;
    public Text itemUpgradeLevelText;
    public Image itemWeaponImage;
    public string itemReestrKey;
    public int itemLevel;
    public int k;
    void Start()
    {
        AssignVariablesStart();
    }

    void Update()
    {
        CheckReestr();
        AssignVariables();
    }
    public void CheckReestr()
    {
        if (weapon.GetComponent<WeaponSpecifications>() != null)
        {
            itemReestrKey = weapon.GetComponent<WeaponSpecifications>().weaponReestrKey;
            if (PlayerPrefs.GetInt(itemReestrKey) != 0)
            {
                itemLevel = PlayerPrefs.GetInt(itemReestrKey);
            }
            else
                PlayerPrefs.SetInt(itemReestrKey, 1);
        }
    }
    public void AssignVariablesStart()
    {
        GameObject weaponImageBG = gameObject.transform.Find("WeaponImageBG").gameObject;
        GameObject weaponName = weaponImageBG.transform.Find("WeaponName").gameObject;
        GameObject nameText = weaponName.transform.Find("NameText").gameObject;
        itemName = nameText.GetComponent<Text>();

        GameObject weaponImage = weaponImageBG.transform.Find("WeaponImage").gameObject;
        itemWeaponImage = weaponImage.GetComponent<Image>();

        GameObject specifications = gameObject.transform.Find("Specifications").gameObject;
        GameObject Damage = specifications.transform.Find("Damage").gameObject;
        GameObject DamageText = Damage.transform.Find("DamageText").gameObject;
        itemDamage = DamageText.GetComponent<Text>();

        GameObject AttackSpeed = specifications.transform.Find("AttackSpeed").gameObject;
        GameObject SpeedText = AttackSpeed.transform.Find("SpeedText").gameObject;
        itemAttackSpeed = SpeedText.GetComponent<Text>();

        GameObject description = gameObject.transform.Find("Description").gameObject;
        GameObject descriptionText = description.transform.Find("DescriptionText").gameObject;
        itemDescription = descriptionText.GetComponent<Text>();
        GameObject upgreadWeaponMenu = gameObject.transform.Find("UpgreadWeaponMenu").gameObject;
        GameObject upgrade = upgreadWeaponMenu.transform.Find("Upgrade").gameObject;
        GameObject upgradeLevelBG = upgrade.transform.Find("UpgradeLevelBG").gameObject;
        GameObject upgradeLevelText = upgradeLevelBG.transform.Find("UpgradeLevelText").gameObject;
        itemUpgradeLevelText = upgradeLevelText.GetComponent<Text>();
    }
    public void AssignVariables()
    {      
        if (weapon.GetComponent<WeaponSpecifications>() != null)
        {
            itemName.text = weapon.GetComponent<WeaponSpecifications>().weaponName.ToString();
            itemDamage.text = (weapon.GetComponent<WeaponSpecifications>().weaponDamage * itemLevel + (itemLevel * 0.5)).ToString();
            itemAttackSpeed.text = (weapon.GetComponent<WeaponSpecifications>().weaponAttackSpeed * itemLevel + (itemLevel * 0.5)).ToString();
            itemDescription.text = weapon.GetComponent<WeaponSpecifications>().weaponDescription.ToString();
            itemWeaponImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
            itemUpgradeLevelText.text = itemLevel.ToString();
        }
    }
    public void UpgradeLevel()
    {
        itemLevel++;
        PlayerPrefs.SetInt(itemReestrKey, itemLevel);
    }
}
