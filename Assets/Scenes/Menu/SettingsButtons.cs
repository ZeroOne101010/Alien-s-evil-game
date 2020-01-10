using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtons : MonoBehaviour
{
    public string url;
    public void OpenURLPage()
    {
        Application.OpenURL(url);
        print("It's work");
    }
}
