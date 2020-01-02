using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInHand : MonoBehaviour
{
    public  GameObject[] Gun = new GameObject[3]; 
    // Start is called before the first frame update
    void Start()
    {
        Gun[0].SetActive(false);
        Gun[1].SetActive(false);
        Gun[2].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Dull":
                Gun[0].SetActive(true);
                Gun[1].SetActive(false);
                Gun[2].SetActive(false);
                break;
                
            case "Pull":
                Gun[1].SetActive(true);
                Gun[0].SetActive(false);
                Gun[2].SetActive(false);
                break;
            case "BigDull":
                Gun[2].SetActive(true);
                Gun[1].SetActive(false);
                Gun[0].SetActive(false);
                break;
        }

    }
}
