using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadRandomLevel : MonoBehaviour
{
    public GameObject BlackoutScreen;
    public static int SizeOfArray;
    private int temp;
    public string[] scenes = new string[SizeOfArray];


    System.Random rnd = new System.Random();

    void Update()
    {
        Load_Random_Level();
    }
    public void Load_Random_Level()
    {

        if (BlackoutScreen.GetComponent<Image>().color.a >= 1)
        {
            temp = Random.Range(0, scenes.Length);
            Debug.Log(temp);
            SceneManager.LoadScene(scenes[temp], LoadSceneMode.Single);
        }

    }
}
