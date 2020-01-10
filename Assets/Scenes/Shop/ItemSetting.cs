using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public delegate void BuyDelegate();
public enum ItemType
{
    other,
    weapon,
    ability
}
public enum BuyLogic
{
    initUpgradeMenu,
    initEquipMenu,
    initAlertMenu
}
public class ItemSetting : MonoBehaviour
{
    private List<GameObject> menu = new List<GameObject>();
    private string itemReestrKey;


    public ItemType itemType;
    public BuyLogic buyLogic;
    public BuyDelegate buyDelegate;

    [Header("Меню посли покупки")]
    public GameObject EquipMenu;
    public GameObject AlertMenu;
    public GameObject UpgreadWeaponMenu;

    [Header("Общие переменные")]
    public GameObject item;
    [HideInInspector]
    public Specifications specifications;
    public Text itemName;
    public Text itemDescription;
    public Text itemPriceText;
    public Image itemImage;


    [Header("Weapon")]
    public WeaponSpecifications weaponSpecifications;
    public Text itemDamage;
    public Text itemAttackSpeed;
    public Text itemUpgradeLevelText;
    public Text itemUpgradePriceText;

    [Space]


    public int itemLevel;
    void Start()
    {
        BuyDelegateInit(ref buyDelegate, buyLogic);
        Init(itemType);
    }

    void Update()
    {
        CheckReestr(itemType);
        AssignVariables(itemType);    }
    public void BuyDelegateInit(ref BuyDelegate buyDelegate, BuyLogic boyLogic )
    {
        switch (boyLogic)
        {
            case BuyLogic.initAlertMenu:
                buyDelegate = InitAlertMenu;
                break;
            case BuyLogic.initEquipMenu:
                buyDelegate = InitEquipMenu;
                break;
            case BuyLogic.initUpgradeMenu:
                buyDelegate = InitUpgradeMenu;
                break;
        }
    }
    public void Init(ItemType itemType)
    {
        menu.Add(EquipMenu);
        menu.Add(AlertMenu);
        menu.Add(UpgreadWeaponMenu);
        specifications = item.GetComponent<Specifications>();
        itemReestrKey = specifications.reestrKey;
        if (itemType == ItemType.weapon)
        {
            weaponSpecifications = item.GetComponent<WeaponSpecifications>();
            if (PlayerPrefs.GetInt(itemReestrKey) <= 0)         
                PlayerPrefs.SetInt(itemReestrKey, 1);                  
            itemLevel = PlayerPrefs.GetInt(itemReestrKey);
        }
    }

    public void CheckReestr(ItemType itemType)
    {
        if (PlayerPrefs.GetInt(itemReestrKey + "IsBought") == 0)
        {
            foreach (GameObject m in menu)
            {
                m.SetActive(false);
            }
        }
        else if (PlayerPrefs.GetInt(itemReestrKey + "IsBought") != 0)
        {
            buyDelegate();
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
            itemUpgradeLevelText.text = itemLevel.ToString();
            itemUpgradePriceText.text = UpgradeLevelFunc(specifications.price, itemLevel).ToString();
            itemDamage.text = (weaponSpecifications.weaponDamage * itemLevel).ToString();
            itemAttackSpeed.text = (weaponSpecifications.weaponAttackSpeed * itemLevel).ToString();
        }
    }
    public void BuyItem()
    {
        if (PlayerPrefs.GetInt(GlobalScript.coinReestrKey) >= specifications.price)
        {
            PlayerPrefs.SetInt(GlobalScript.coinReestrKey, PlayerPrefs.GetInt(GlobalScript.coinReestrKey) - (int)specifications.price);
            PlayerPrefs.SetInt(itemReestrKey + "IsBought", 1);
        }
    }
    public void UpgradeLevel()
    {
        if(PlayerPrefs.GetInt(GlobalScript.coinReestrKey) >= UpgradeLevelFunc(specifications.price, itemLevel))
        {
            itemLevel++;
            PlayerPrefs.SetInt(GlobalScript.coinReestrKey, (int)(PlayerPrefs.GetInt(GlobalScript.coinReestrKey) - UpgradeLevelFunc(specifications.price, itemLevel)));
            PlayerPrefs.SetInt(itemReestrKey, itemLevel);
        }
    }
    public void InitAlertMenu()
    {
        AlertMenu.SetActive(true);
    }
    public void InitUpgradeMenu()
    {
        UpgreadWeaponMenu.SetActive(true);
    }
    public void InitEquipMenu()
    {
        EquipMenu.SetActive(true);
    }
    public float UpgradeLevelFunc(float weaponPrice, float itemLevel)
    {
        return weaponPrice + ((weaponPrice * itemLevel) / 4);
    }
}
