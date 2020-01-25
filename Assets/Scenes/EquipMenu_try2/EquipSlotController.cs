using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlotController : MonoBehaviour
{
    public GameObject sectionController;    
    public GameObject[] equipWeaponInSlotScrolls;
    void Start()
    {
        
    }

    void Update()
    {
        GlobalScript.ActivateSelectedElementFromArray(equipWeaponInSlotScrolls, sectionController.GetComponent<SectionController>().selectedSection);
    }
}
