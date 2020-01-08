using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintText : MonoBehaviour
{
    public void printthetext()
    {
        if (GetComponentInParent<Button>())
        {
            print("GG");
        }
    }
}
