using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.GetComponent<StatOfLevel>().cgold += 1;
            player.GetComponent<PrefStatOfHero>().CountOfGold += 1;
            player.GetComponent<PrefStatOfHero>().Save();
            Destroy(gameObject);
        }
    }
    
    
}
