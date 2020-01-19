using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionController : MonoBehaviour
{
    public int selectedSection;
    public GameObject[] sections;
    public GameObject[] buttons;
    public void Start()
    {
    }
    public void ActivateSection(int section)
    {
        bool alredyChoosed = selectedSection == section ? true : false;
        selectedSection = section;
        sections[selectedSection].SetActive(true);
        for (int i = 0; i < sections.Length; i++)
        {
            if (i != selectedSection)
                sections[i].SetActive(false);
        }
        if(alredyChoosed == false)
        ActivateSelectionEffect(selectedSection);
    }
    public void ActivateSelectionEffect(int section)
    {
        SectionEffect[] sectionEffects = sections[section].GetComponents<SectionEffect>();
        SectionEffect[] buttonSectionEffects = buttons[section].GetComponents<SectionEffect>();
        for (int k = 0; k < sectionEffects.Length; k++)
        {
            sectionEffects[k].Effect();
        }
        for (int l = 0; l < buttonSectionEffects.Length; l++)
        {
            buttonSectionEffects[l].Effect();
        }
    }

}
