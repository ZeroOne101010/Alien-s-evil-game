using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public GameObject BlackoutScreen;
    void Update()
    {
        Quit();
    }
    public void Quit()
    {
            Debug.Log("YOU QUITED");
            Application.Quit();
        
    }
}
