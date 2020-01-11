using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSectionScript : MonoBehaviour
{
    public GameObject section;
    [HideInInspector]
    public int sectionIndex;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ChooseSection()
    {
        EquipManager.selectedSection = sectionIndex;
    }
}
