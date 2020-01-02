using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCount : MonoBehaviour
{

    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Level").ToString();
    }
}
