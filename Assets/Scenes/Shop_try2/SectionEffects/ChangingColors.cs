using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingColors : MonoBehaviour
{
    [HideInInspector]
    public Color initalColor;
    public Color color;
    private void Awake()
    {
        if(GetComponent<Image>() != null)
            initalColor = GetComponent<Image>().color;
        if (GetComponent<Text>() != null)
            initalColor = GetComponent<Text>().color;
    }
}
