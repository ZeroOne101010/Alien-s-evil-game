using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfCloud : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public GameObject[] clouds = new GameObject[3];
    public float TimeOfSpawn;
    int y,cloud;
    private void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeOfSpawn);
            y = rnd.Next(-8, 8);
            transform.position = new Vector2(transform.position.x, y);
            cloud = rnd.Next(0, 3);
            Instantiate(clouds[cloud], new Vector2(transform.position.x,y),Quaternion.identity);
        }
        
    }
}
