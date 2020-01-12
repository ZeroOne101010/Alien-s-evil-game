using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSectionScript : MonoBehaviour
{
    public GameObject section;
    [HideInInspector]
    public int sectionIndex;
    public Text itemTypeText;
    public Text itemNameText;
    public Image BG1;
    public Image BG2;
    public Color textColorNew;
    public Color lightBGcolorNew;
    public Color darkBGcolorNew;
    private Color textColor;
    private Color lightBGcolor;
    private Color darkBGcolor;
    void Start()
    {
        InitTemporaryVariables();
    }

    void Update()
    {
        SelectChangeColor();
    }
    public void InitTemporaryVariables()
    {
        textColor = itemTypeText.color;
        lightBGcolor = BG1.color;
        darkBGcolor = BG2.color;
    }
    public void ChooseSection()
    {
        EquipManager.selectedSection = sectionIndex;
    }
    public void SelectChangeColor()
    {
        if (EquipManager.selectedSection == sectionIndex)
        {
            itemTypeText.color = textColorNew;
            itemNameText.color = textColorNew;
            BG1.color = lightBGcolorNew;
            BG2.color = lightBGcolorNew;
            GetComponent<Image>().color = darkBGcolorNew;
        }
        else
        {
            itemTypeText.color = textColor;
            itemNameText.color = textColor;
            BG1.color = lightBGcolor;
            BG2.color = lightBGcolor;
            GetComponent<Image>().color = darkBGcolor;
        }

    }
}
