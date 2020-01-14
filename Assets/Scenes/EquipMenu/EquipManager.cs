using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public GameObject[] HaveItemSections;
    public GameObject choosedSection;
    public static int selectedSection;
    public int selectedSectionPUBLIC;
    void Start()
    {

    }

    void Update()
    {
        selectedSectionPUBLIC = selectedSection;
        SectionLogic();
        EquipSectionLogic();
    }
    public void SectionLogic()
    {
        for (int i = 0; i < HaveItemSections.Length; i++)
        {
            if (HaveItemSections[i].GetComponent<EquipSectionScript>() != null)
                HaveItemSections[i].GetComponent<EquipSectionScript>().sectionIndex = i;

            if (selectedSection == HaveItemSections[i].GetComponent<EquipSectionScript>().sectionIndex)
            {
                HaveItemSections[i].GetComponent<EquipSectionScript>().section.SetActive(true);
            }
            else if (selectedSection != HaveItemSections[i].GetComponent<EquipSectionScript>().sectionIndex)
            {
                HaveItemSections[i].GetComponent<EquipSectionScript>().section.SetActive(false);
            }
        }
    }
    public void EquipSectionLogic()
    {
        for(int i = 0; i < HaveItemSections.Length; i++)
        {
            if(HaveItemSections[i].GetComponent<EquipSectionScript>().sectionIndex == selectedSection)
            {
                choosedSection = HaveItemSections[i];
            }
        }   
    }
}
