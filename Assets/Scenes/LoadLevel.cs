using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public GameObject BlackoutScreen;
    public string scene;

    void Update()
    {
        Load_Level();
    }
    public void Load_Level()
    {
        if (BlackoutScreen.GetComponent<Image>().color.a >= 1)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
