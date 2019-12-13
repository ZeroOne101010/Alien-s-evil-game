using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public GameObject BlackoutScreen;
    public void Quit()
    {
            Debug.Log("YOU QUITED");
            Application.Quit();
        
    }
}
