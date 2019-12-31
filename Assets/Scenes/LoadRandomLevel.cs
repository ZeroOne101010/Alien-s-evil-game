using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadRandomLevel : MonoBehaviour
{
    public static int SizeOfArray;
    private int temp;
    public string[] scenes = new string[SizeOfArray];
    System.Random rnd = new System.Random();

    void Update()
    {
    }
    public void Load_Random_Level()
    {
            temp = Random.Range(0, scenes.Length);
            SceneManager.LoadScene(scenes[temp], LoadSceneMode.Single);
        

    }
}
