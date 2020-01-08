using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCreateParticles : ShotEffect
{

    public GameObject prifabParticle;
    public int count;
    public float speedMove;

    public override void effect(Vector3 offsetShot)
    {
        for (int x = 0; x < count; x++)
        {
            Quaternion randomQu = new Quaternion(Random.Range(0, 360), 0, 0, 0);
            GameObject particle = Instantiate(prifabParticle, transform.position + offsetShot, randomQu);
            Rigidbody2D rigid = particle.GetComponent<Rigidbody2D>();
            if(rigid != null)
            {
                float k = Random.Range(0.000f, 3.1400f * 2);
                float randomSpeed = Random.Range(speedMove * 0.5f, speedMove);
                rigid.velocity = new Vector2(Mathf.Cos(k), Mathf.Sin(k)) * randomSpeed;
            }
        }
    }
}
