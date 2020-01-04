using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    public GameObject hittedObj;
    void Start()
    {

    }


    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       // if (collision.tag == "hurtbox")
       // {
           // print(collision.tag);
           // if (collision.transform.parent.transform.position != null)
            //{
           //     collision.transform.parent.transform.position = new Vector3(0, 0, 0);
          //      if (collision.transform.parent.GetComponent<ObjectInformation>() != null)
          //          if (collision.transform.parent.GetComponent<ObjectInformation>().whoIsIt == "player")
           //         {
                        
           //         }
           // }
       // }
       if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Entity>().health -= 10;
        }
    }
}
