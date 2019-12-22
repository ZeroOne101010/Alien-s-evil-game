using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    
    public GameObject bulletPref;
    private GameObject bullet;
    public void Shoot()
    {
        bullet = Instantiate(bulletPref, transform.position, transform.rotation);
        Destroy(bullet, 10);
    }
}
