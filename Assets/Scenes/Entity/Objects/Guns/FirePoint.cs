using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    
    public GameObject bulletPref;
    private GameObject bullet;
    public float speed;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        bullet = Instantiate(bulletPref, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * speed, ForceMode2D.Force);
        Destroy(bullet, 10);
    }
}
