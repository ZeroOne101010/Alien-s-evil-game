using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintStatOnBoardSetting : MonoBehaviour
{
    public string AboutThisStat;
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if(AboutThisStat == "Gold")
        {
            //GetComponent<Text>().text = player.GetComponent<StatOfLevel>().cgold.ToString();
        }
        if (AboutThisStat == "Exp")
        {
            //GetComponent<Text>().text = player.GetComponent<StatOfLevel>().cexp.ToString();
        }
    }
}
