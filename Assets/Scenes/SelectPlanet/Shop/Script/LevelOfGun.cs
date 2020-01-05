using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOfGun : MonoBehaviour
{
    public string TypeOfGun;
    
    

    
    void Update()
    {
        GetComponent<Text>().text = "Level " + PlayerPrefs.GetInt(TypeOfGun).ToString();
    }
}
