using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamBullets : WeaponShot
{
    public Vector2 direction;
    public Vector2 sizeFieldSpawnBullets;
    public GameObject[] bulletPrifab;

    public override void startWeaponShot()
    {
        base.startWeaponShot();
    }

    public override void updateWeaponShot()
    {
        base.updateWeaponShot();
    }

    public override void shot(Vector3 offsetShot)
    {
        Vector3 randomOffset = new Vector3(Random.Range(-sizeFieldSpawnBullets.x, sizeFieldSpawnBullets.x), Random.Range(-sizeFieldSpawnBullets.y, sizeFieldSpawnBullets.y));
        Vector3 spawnPos = randomOffset + offsetShot + transform.position;
        int id = Random.Range(0, bulletPrifab.Length);
        GameObject bullet = Instantiate(bulletPrifab[id], spawnPos, Quaternion.identity);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        float isRight = getKeepedEntity().GetComponent<EntityMoveController>().isRight ? 1 : -1;
        Vector2 direction = new Vector2(this.direction.x * isRight, this.direction.y);
        bulletController.initBullet(getTeamId(), direction, gameObject, this);
    }

}