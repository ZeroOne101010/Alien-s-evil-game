using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfBox : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public int TimeOfSpawn;
    public GameObject BoxWithGun;
    private int x;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            x = rnd.Next(-20, 20);
            yield return new WaitForSeconds(TimeOfSpawn);
            Instantiate(BoxWithGun, new Vector2(x, transform.position.y), Quaternion.identity);
        }
    }
}
