using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject[] shopSections;
    public static int selectedSection;
    void Start()
    {
        
    }

    void Update()
    {
        SectionLogic();
    }
    public void SectionLogic()
    {
        for(int i = 0; i < shopSections.Length; i++)
        {
            if(shopSections[i].GetComponent<SectionScript>() != null)
            shopSections[i].GetComponent<SectionScript>().sectionIndex = i;

            //shopSections[i].GetComponent<SectionScript>().section.SetActive(false);
            if(selectedSection == shopSections[i].GetComponent<SectionScript>().sectionIndex)
            {
                shopSections[i].GetComponent<SectionScript>().section.SetActive(true);
            }
            else if(selectedSection != shopSections[i].GetComponent<SectionScript>().sectionIndex)
            {
                shopSections[i].GetComponent<SectionScript>().section.SetActive(false);
            }
        }
    }
}
