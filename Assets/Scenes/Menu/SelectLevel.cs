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
        LoadSelectLevel();
        Debug.Log(BlackoutScreen.GetComponent<Image>().color.a);
    }
    public void LoadSelectLevel()
    {
        if (BlackoutScreen.GetComponent<Image>().color.a >= 1)
        {
            Debug.Log("Соси писюн");
            SceneManager.LoadScene(Scene, LoadSceneMode.Single);
        }
    }
}
