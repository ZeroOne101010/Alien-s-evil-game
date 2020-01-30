using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : EntityDeathEffect
{

    public GameObject[] obj;
    public int[] countObj;
    public Vector2 offsetSpawn;

    public float minForce;
    public float maxForce;

    public override void effectStart()
    {
        base.effectStart();
        Vector2 spawnPos = (Vector2)transform.position + offsetSpawn;
        for(int x = 0; x < obj.Length; x++)
        {
            float deltaAngle = (Mathf.PI * 2.00f) / countObj[x];
            for (int y = 0; y < countObj[x]; y++)
            {
                Vector2 directionForce = new Vector2(Mathf.Cos(deltaAngle * y), Mathf.Sin(deltaAngle * y));
                GameObject spawnedObject = Instantiate(obj[x], spawnPos, Quaternion.identity);
                Rigidbody2D rigid = spawnedObject.GetComponent<Rigidbody2D>();
                float f = Random.Range(minForce, maxForce);
                rigid.AddForce(directionForce * f);
            }
        }
    }

}
