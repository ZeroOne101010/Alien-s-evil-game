using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadOfLightning : BulletScript
{

    public GameObject[] spreadGameObject;

    public Vector2 offsetSpawn;

    public int maxCountSpread;
    public int ScatterSpread;

    public int timeToSpreadLighting;

    [HideInInspector]
    public int spreadId;

    [HideInInspector]
    public Vector2 directionSpread;


    [HideInInspector]
    public bool isFirstLighting = true;

    private int timerToSpreadLighting;
    private StreamBullets streamBullet;

    public override void bulletStart()
    {
        base.bulletStart();
        isFirstLighting = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        timerToSpreadLighting = timeToSpreadLighting;
    }


    public void startSpread()
    {
        if (isFirstLighting)
        {
            spreadId = Random.Range(maxCountSpread - ScatterSpread, maxCountSpread);
            if (isFirstLighting)
            {
                WeaponController weaponController = weapon.GetComponent<WeaponController>();
                EntityController entity = weaponController.keepedEntity.GetComponent<EntityController>();
                EntityMove entityMove = entity.GetComponent<EntityMove>();
                float direction = 0;

                if (entityMove != null)
                {
                    direction = entityMove.isRight ? 1 : 0;
                }

                directionSpread = new Vector2(direction, 0);
            }
            isFirstLighting = false;
        }
    }

    public void spreadLighting()
    {
        if (spreadId > 0)
        {
            int idSpreadGameObject = Random.Range(0, spreadGameObject.Length);

            Quaternion randQu = new Quaternion(0, 0, Random.Range(110, 250), 0);

            GameObject bullet = Instantiate(spreadGameObject[idSpreadGameObject], new Vector2(offsetSpawn.x * directionSpread.x, Random.Range(-offsetSpawn.y, offsetSpawn.y)), randQu);

            SpreadOfLightning spreadOfLighting = bullet.GetComponent<SpreadOfLightning>();
            if (spreadOfLighting != null)
            {
                spreadOfLighting.isFirstLighting = false;
                spreadOfLighting.directionSpread = directionSpread;
                spreadOfLighting.spreadId = spreadId - 1;
                spreadOfLighting.startSpread();
            }
        }
    }

    public override void bulletUpdate()
    {
        startSpread();
        timerToSpreadLighting--;
        if (timerToSpreadLighting < 0) timerToSpreadLighting = 0;
        if(timerToSpreadLighting == 0)
        {
            spreadLighting();
            timerToSpreadLighting = timeToSpreadLighting;
        }

        base.bulletUpdate();
    }

}
