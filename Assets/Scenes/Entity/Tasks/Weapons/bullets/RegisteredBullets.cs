using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BulletImplementation(float damage, Vector2 diraction, GameObject bullet); 
public class RegisteredBullets : MonoBehaviour
{
    public GameObject DullBullet;
    public GameObject PullBullet;
    public GameObject BigDullBullet;
    static public List<BulletImplementation> bulletImplementation = new List<BulletImplementation>();
    public void Start()
    {
        bulletImplementation.Add(DullBulletImplemention);    // 0
        bulletImplementation.Add(PullBulletImplemention);    // 1
        bulletImplementation.Add(BigDullBulletImplemention); // 2
    }

    static public void DullBulletImplemention(float damage, Vector2 diraction, GameObject bullet)
    {
        if (bullet.GetComponent<Rigidbody2D>() != null)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(20 * diraction.x, 0);
        }
            
    }
    static public void PullBulletImplemention(float damage, Vector2 diraction, GameObject bullet)
    {

    }
    static public void BigDullBulletImplemention(float damage, Vector2 diraction, GameObject bullet)
    {

    }
}
