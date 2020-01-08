using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionScript : MonoBehaviour
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
        ShopManager.selectedSection = sectionIndex;
    }
}
