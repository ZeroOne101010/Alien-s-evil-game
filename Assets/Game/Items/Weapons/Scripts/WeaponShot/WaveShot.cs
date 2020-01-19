using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShot : WeaponShot
{
    public GameObject[] BulletPrefab;
    public int CountBullets;
    public float angleShot;
    public float AngleGap;
    public Vector2 OffsetShot;
    public override void shot(Vector3 offsetShot)
    {
        GameObject[] Bullet = new GameObject[CountBullets];
        for (int i = 0; i < CountBullets; i++)
        {
            int bulletPrifabId = Random.Range(0, BulletPrefab.Length);
            float isRight = getKeepedEntity().GetComponent<EntityMove>().isRight ? 1 : -1;
            Vector2 spawnPos = (Vector2)(transform.position) + OffsetShot * isRight;
            Bullet[i] = Instantiate(BulletPrefab[bulletPrifabId], spawnPos, Quaternion.identity);
            BulletController bulletController = Bullet[i].GetComponent<BulletController>();
            float angle = (AngleGap / CountBullets) * (i + 1) - (AngleGap / 2);
            float radAngle = (((angleShot + angle) / 360) * 2 * Mathf.PI);
            Vector2 direction = new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle)) * isRight;
            bulletController.initBullet(getTeamId(), direction, gameObject, this);
        }
    }
}
