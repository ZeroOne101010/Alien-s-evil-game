using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBang : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>() && collision.GetComponent<Entity>().TagOfGameEntity == "Player")
        {
            
            collision.GetComponent<Entity>().health -= 50;
            gameObject.GetComponentInParent<Entity>().health = 0;
        }
    }
}
