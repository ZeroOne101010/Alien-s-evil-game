using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveElementInSectionScript : MonoBehaviour
{
    public ItemType itemType;
    public GameObject content;
    public List<GameObject> elements = new List<GameObject>();
    private GameObject weaponsIDsManager;
    void Start()
    {
        weaponsIDsManager = GameObject.FindGameObjectWithTag("WeaponsID");
    }


    void Update()
    {
        CheckElementsInManagerWeaponID();
    }
    public void CheckElementsInManagerWeaponID()
    {
        //for (int i = 0; i < weaponsIDsManager.GetComponent<WeaponIDs>().weaponsID.Length; i++)
        //{
        //    if (weaponsIDsManager.GetComponent<WeaponIDs>().weaponsID[i].GetComponent<Specifications>().itemType == itemType)
        //        if (weaponsIDsManager.GetComponent<WeaponIDs>().weaponsID[i].GetComponent<Specifications>().isBought == true)
        //        {
        //            bool alreadyIs = false;
        //            for (int itemI = 0; itemI < elements.Count; itemI++)
        //            {
        //                if (elements[itemI] == weaponsIDsManager.GetComponent<WeaponIDs>().weaponsID[i])
        //                {
        //                    alreadyIs = true;                            
        //                }
        //            }
        //            if (alreadyIs == false)
        //            {
        //                elements.Add(weaponsIDsManager.GetComponent<WeaponIDs>().weaponsID[i]);
        //                for (int k = 0; k < elements.Count; k++)
        //                {
        //                    if (elements[k] == weaponsIDsManager.GetComponent<WeaponIDs>().weaponsID[i])
        //                        elements[k] = Instantiate(weaponsIDsManager.GetComponent<WeaponIDs>().weaponsID[i], content.transform);
        //                }
        //            }
        //        }
        //}

    }
}
