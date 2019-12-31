using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBang : MonoBehaviour
{
    private Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>() && collision.GetComponent<Entity>().TagOfGameEntity == "Player")
        {
            anim = GetComponentInParent<Animator>();
            anim.SetBool("Explosion",true);
            collision.GetComponent<Entity>().health -= 50;
            gameObject.GetComponentInParent<Entity>().health = 0;
        }
    }
}
