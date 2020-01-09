using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    other,
    weapon,
    ability
}
public class ItemSetting : MonoBehaviour
{
    public ItemType itemType;
    public bool isWeareable;
    [Header("Общие переменные")]
    public GameObject item;
    public Text itemName;
    public Text itemDescription;
    public Text itemPriceText;
    public Image itemImage;
    public GameObject EquipMenu;
    public GameObject AlertMenu;
    [HideInInspector]
    public Specifications specifications;
    [Header("Weapon")]
    public WeaponSpecifications weaponSpecifications;
    public Text itemDamage;
    public Text itemAttackSpeed;
    public Text itemUpgradeLevelText;
    public Text itemUpgradePriceText;
    public GameObject UpgreadWeaponMenu;
    [Space]

    private string itemReestrKey;
    public int itemLevel;
    void Start()
    {
        Init(itemType);
        PlayerPrefs.SetInt(GlobalScript.coinReestrKey, 5000);
        //PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        CheckReestr(itemType);
        AssignVariables(itemType);    }
    public void Init(ItemType itemType)
    {
        if (itemType == ItemType.other)
        {
            specifications = item.GetComponent<Specifications>();
            itemReestrKey = specifications.reestrKey;
        }

        if (itemType == ItemType.weapon)
        {
            weaponSpecifications = item.GetComponent<WeaponSpecifications>();
            if (weaponSpecifications != null)
                itemReestrKey = weaponSpecifications.weaponReestrKey;
        }


    }
    public void CheckReestr(ItemType itemType)
    {
        if (itemType == ItemType.other)
        {
            if (PlayerPrefs.GetInt(itemReestrKey + "IsBought") == 0)
            {
                EquipMenu.SetActive(false);
                AlertMenu.SetActive(false);
            }
            else if (PlayerPrefs.GetInt(itemReestrKey + "IsBought") != 0)
            {
                if (isWeareable == true)
                {
                    EquipMenu.SetActive(true);
                }
                else
                {
                    AlertMenu.SetActive(true);
                }
            }
        }

        if (itemType == ItemType.weapon)
        {
            if (weaponSpecifications != null)
            {
                itemReestrKey = weaponSpecifications.weaponReestrKey;

                if (PlayerPrefs.GetInt(itemReestrKey) != 0)
                {
                    itemLevel = PlayerPrefs.GetInt(itemReestrKey);
                }
                else
                    PlayerPrefs.SetInt(itemReestrKey, 1);

                if (PlayerPrefs.GetInt(itemReestrKey + "IsBought") == 0)
                {
                    UpgreadWeaponMenu.SetActive(false);
                }
                else if (PlayerPrefs.GetInt(itemReestrKey + "IsBought") != 0)
                {
                    UpgreadWeaponMenu.SetActive(true);
                }
            }
        }
        if (itemType == ItemType.ability)
        {

        }
        
    }
    public void AssignVariables(ItemType itemType)
    {
        itemName.text = specifications.Name.ToString();
        itemDescription.text = specifications.description.ToString();
        itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        itemPriceText.text = specifications.price.ToString();

        if (itemType == ItemType.weapon)
        {
            if (weaponSpecifications != null)
            {
                itemName.text = weaponSpecifications.weaponName.ToString();
                itemDamage.text = (weaponSpecifications.weaponDamage * itemLevel).ToString();
                itemAttackSpeed.text = (weaponSpecifications.weaponAttackSpeed * itemLevel).ToString();
                itemDescription.text = weaponSpecifications.weaponDescription.ToString();
                itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
                itemUpgradeLevelText.text = itemLevel.ToString();
                itemPriceText.text = weaponSpecifications.weaponPrice.ToString();
                itemUpgradePriceText.text = UpgradeLevelFunc(weaponSpecifications.weaponPrice, itemLevel).ToString();
            }
        }
        if (itemType == ItemType.ability)
        {

        }
    }
    public void BuyItem()
    {
        if (PlayerPrefs.GetInt(GlobalScript.coinReestrKey) >= specifications.price)
        {
            PlayerPrefs.SetInt(GlobalScript.coinReestrKey, PlayerPrefs.GetInt(GlobalScript.coinReestrKey) - (int)specifications.price);
            PlayerPrefs.SetInt(itemReestrKey + "IsBought", 1);
            print("Kek");
        }
        print("Kek");
        if (itemType == ItemType.weapon)
        {
            if (PlayerPrefs.GetInt(GlobalScript.coinReestrKey) >= weaponSpecifications.weaponPrice)
            {
                PlayerPrefs.SetInt(GlobalScript.coinReestrKey, PlayerPrefs.GetInt(GlobalScript.coinReestrKey) - (int)weaponSpecifications.weaponPrice);
                PlayerPrefs.SetInt(itemReestrKey + "IsBought", 1);
                print("Kek");
            }
            print("Kek");
        }
        if (itemType == ItemType.ability)
        {

        }

    }
    public void UpgradeLevel()
    {
        if(PlayerPrefs.GetInt(GlobalScript.coinReestrKey) >= UpgradeLevelFunc(weaponSpecifications.weaponPrice, itemLevel))
        {
            itemLevel++;
            PlayerPrefs.SetInt(GlobalScript.coinReestrKey, (int)(PlayerPrefs.GetInt(GlobalScript.coinReestrKey) - UpgradeLevelFunc(weaponSpecifications.weaponPrice, itemLevel)));
            PlayerPrefs.SetInt(itemReestrKey, itemLevel);
        }
    }
    public float UpgradeLevelFunc(float weaponPrice, float itemLevel)
    {
        return weaponPrice + ((weaponPrice * itemLevel) / 4);
    }
}
