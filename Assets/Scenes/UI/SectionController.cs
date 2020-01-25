using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionController : MonoBehaviour
{
    public int selectedSection;
    public bool noSections;
    public GameObject[] sections;
    public GameObject[] buttons;
    public void Awake()
    {
        //GiveSelectedButtonValueInSections();
        GiveselectedSectionDataTokElementController();
    }
    public void Start()
    {
        if(noSections == false)
        {
            ActivateSection(selectedSection);
        }
    }
    public void Update()
    {
    }
    public void Click(int section)
    {
        bool alredyChoosed = selectedSection == section ? true : false;
        selectedSection = section;
        for (int k = 0; k < buttons.Length; k++)
        {
            if (k != selectedSection)
            {
                DeactivateSelectionEffect(k);
            }
            else
            {
                if(alredyChoosed == false)
                buttons[k].GetComponent<kElementController>().ClickEffectsActivate();
            }
        }
    }
    public void ActivateSection(int section)
    {
        bool alredyChoosed = selectedSection == section ? true : false;
        selectedSection = section;
        sections[selectedSection].SetActive(true);
        for (int i = 0; i < sections.Length; i++)
        {
            if (i != selectedSection)
            {
                DeactivateSelectionEffect(i);
                sections[i].SetActive(false);
            }
        }
        if(alredyChoosed == false)
        ActivateSelectionEffect(selectedSection);
    }
    public void GiveselectedSectionDataTokElementController()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<kElementController>().selectedID = selectedSection;
            buttons[i].GetComponent<kElementController>().ID = i;
        }
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
    public void DeactivateSelectionEffect(int section)
    {
        SectionEffect[] buttonSectionEffects = buttons[section].GetComponents<SectionEffect>();
        if (noSections == false)
        {
            SectionEffect[] sectionEffects = sections[section].GetComponents<SectionEffect>();
            for (int k = 0; k < sectionEffects.Length; k++)
            {
                sectionEffects[k].DeEffect();
            }
        }


        for (int l = 0; l < buttonSectionEffects.Length; l++)
        {
            buttonSectionEffects[l].DeEffect();
        }
    }

}
