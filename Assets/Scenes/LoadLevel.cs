using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public string scene;
    public void Load_Level()
    {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        
    }
}
