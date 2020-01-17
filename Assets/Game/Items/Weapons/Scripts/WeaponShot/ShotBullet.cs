using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : WeaponShot
{

    public GameObject bullet;
    private WeaponController weaponController;

    public override void startWeaponShot()
    {
        base.startWeaponShot();
        weaponController = GetComponent<WeaponController>();
    }

    public override void updateWeaponShot()
    {
        base.updateWeaponShot();
    }

    public override void shot(Vector3 offsetShot)
    {
        Vector3 direction = transform.up;
        Vector3 shotPos =  offsetShot + transform.position;
        GameObject createdBullet = Instantiate(bullet, shotPos, Quaternion.identity);
        BulletController bulletController = createdBullet.GetComponent<BulletController>();
        if (bulletController != null)
        {
            bool isRight = false;
            GameObject entity = GetComponent<WeaponController>().keepedEntity;
            EntityMove entityMove = entity.GetComponent<EntityMove>();
            if (entityMove != null)
            {
                isRight = entityMove.isRight;
            }

            Vector2 directionBullet = isRight ? new Vector2(1, 0) : new Vector2(-1, 0);

            if (isRight)
            {
                createdBullet.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                createdBullet.transform.rotation = new Quaternion(0, -1, 0, 0);
            }

            bulletController.initBullet(getTeamId(), directionBullet, gameObject, this);

        }

    }
}
