using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGun : MonoBehaviour
{
    public int TimeOfDestroy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(TimeOfDestroy);
        Destroy(gameObject);
    }
}
