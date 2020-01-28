using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCreateParticles : ShotEffect
{

    public GameObject prifabParticle;
    public int count;
    public float speedMove;
    public Vector2 offsetShot;

    public override void effect(bool isRight)
    {
        
        for (int x = 0; x < count; x++)
        {
            float g = isRight ? 1 : -1;
            float qu = isRight ? 0 : -180;
            Quaternion randomQu = new Quaternion(0, 0, qu, 0);
            GameObject particle = Instantiate(prifabParticle, transform.position + (Vector3)(new Vector2(offsetShot.x * g, offsetShot.y)), randomQu);
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
