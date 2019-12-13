using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackoutScreen : MonoBehaviour
{
    public GameObject blackoutscreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LockUp()
    {
        if (blackoutscreen.active == false)
        {
            blackoutscreen.SetActive(true);
        }

    }
}
