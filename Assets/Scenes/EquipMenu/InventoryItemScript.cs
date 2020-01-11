using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour
{
    public ItemType itemType;
    [Header("Общие переменные")]
    public GameObject item;
    public Text itemName;
    public Image itemImage;
    [HideInInspector]
    public Specifications specifications;

    void Start()
    {
        InitVariables();
        FillFields();
    }

    void Update()
    {

    }
    public void InitVariables()
    {
        specifications = item.GetComponent<Specifications>();
    }
    public void FillFields()
    {
        itemName.text = specifications.Name;
        itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        itemImage.preserveAspect = true;
    }

}
