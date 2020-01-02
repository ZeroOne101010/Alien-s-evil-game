using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFromBox : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public GameObject[] GunsInBox = new GameObject[0];
    private int RandomGun;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "Island")
        {
            
            RandomGun = rnd.Next(0, GunsInBox.Length);
            Instantiate(GunsInBox[RandomGun], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
