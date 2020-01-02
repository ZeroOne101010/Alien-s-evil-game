using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideExp : MonoBehaviour
{
    public Slider slide;
    public int CountOfLevel = 1;
    void Update()
    {
        slide.value = PlayerPrefs.GetInt("Exp");
        slide.maxValue = CountOfLevel * 100;
        if (slide.value == slide.maxValue)
        {
            CountOfLevel++;
            PlayerPrefs.SetInt("Level", CountOfLevel);
            PlayerPrefs.SetInt("Experiance", 0);
            PlayerPrefs.Save();
            slide.value = 0;
        }
           
    }
}
