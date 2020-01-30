using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeaponType : MonoBehaviour
{
    public GameObject chooseWeaponPanel;
    public void IncrementSwitch(int value)
    {

        //if (chooseWeaponPanel.GetComponent<ChooseWeaponController>().weaponsTypeID + value > chooseWeaponPanel.GetComponent<ChooseWeaponController>().PrefabManager.GetComponent<PrefabManagerScript>().typesCount - 1)
        //{
        //    chooseWeaponPanel.GetComponent<ChooseWeaponController>().weaponsTypeID = 0;
        //}
        //else if (chooseWeaponPanel.GetComponent<ChooseWeaponController>().weaponsTypeID + value < 0)
        //{
        //    chooseWeaponPanel.GetComponent<ChooseWeaponController>().weaponsTypeID = chooseWeaponPanel.GetComponent<ChooseWeaponController>().PrefabManager.GetComponent<PrefabManagerScript>().typesCount - 1;
        //}
        //else
        //{
        //    chooseWeaponPanel.GetComponent<ChooseWeaponController>().weaponsTypeID += value;
        //}
        Debug.LogError("В скрипте SwitchWeaponType закаментирована большая часть кода, из за недостатка разных типов оружия, обязательно после добавления следующего типа оужия. Убрать закоментирование и доделать!");
        chooseWeaponPanel.GetComponent<ChooseWeaponController>().ClearScrollAndSlots();
        chooseWeaponPanel.GetComponent<ChooseWeaponController>().FillSlots();
    }
}
