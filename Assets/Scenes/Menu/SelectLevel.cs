using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectLevel : MonoBehaviour
{
    public GameObject BlackoutScreen;
    public string Scene;
    private void Update()
    {
        LoadLevel();
    }
    public void LoadLevel()
    {
        if (BlackoutScreen.GetComponent<Image>().color.a >= 1)
        {
            SceneManager.LoadScene(Scene, LoadSceneMode.Single);
        }
    }
    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
