using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject lvlsound;

    // Use this for initialization
    void Start()
    {
        var lvlsound = GameObject.Find("lvlsound");
        if (lvlsound == null)
        {
            lvlsound = (GameObject)Instantiate(Resources.Load("lvlsound"));
            lvlsound.name = "lvlsound";
        }
        DontDestroyOnLoad(lvlsound);
    }
}
