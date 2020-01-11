using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpeedForStart : BulletScript
{

    public float minSpeed;
    public float maxSpeed;

    [HideInInspector]
    public float speed;

    private BulletController bulletController;

    public override void bulletInit()
    {
        base.bulletInit();
        bulletController = GetComponent<BulletController>();
        setForceBullet();
    }



    public override void bulletUpdate()
    {
        base.bulletUpdate();
    }

    public void setForceBullet()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeed, maxSpeed);
        rigid.velocity = bulletController.direction * speed;
        bulletController.speedMove = speed;
    }

}
