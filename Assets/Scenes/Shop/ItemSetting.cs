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
    public Image itemWeaponImage;
    void Start()
    {
        AssignVariables();
    }

    void Update()
    {
        
    }
    public void AssignVariables()
    {
        
        if (weapon.GetComponent<WeaponSpecifications>() != null)
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



            itemName.text = weapon.GetComponent<WeaponSpecifications>().weaponName.ToString();
            itemDamage.text = weapon.GetComponent<WeaponSpecifications>().weaponDamage.ToString();
            itemAttackSpeed.text = weapon.GetComponent<WeaponSpecifications>().weaponAttackSpeed.ToString();
            itemDescription.text = weapon.GetComponent<WeaponSpecifications>().weaponDescription.ToString();
            itemWeaponImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
            //itemAttackSpeed = specifications.transform.Find("AttackSpeed").gameObject.transform.Find("SpeedText").gameObject.GetComponent<Text>();
            //itemDamage.text = "KEK";
        }
    }
}
