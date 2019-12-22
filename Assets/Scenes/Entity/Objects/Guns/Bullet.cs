using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>())
        {
            collision.GetComponent<Entity>().health -= damage;
            print(collision.GetComponent<Entity>().health);
            Destroy(gameObject);
        }
    }

}
