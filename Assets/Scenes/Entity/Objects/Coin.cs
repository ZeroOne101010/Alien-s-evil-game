using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            
            GameObject player = collision.gameObject;
            player.GetComponent<CounterOfCoins>().CountOfGetCoins += 1;
            Destroy(gameObject);
        }
    }
}
