using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfBox : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public int TimeOfSpawn;
    public GameObject BoxWithGun;
    int x;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
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
