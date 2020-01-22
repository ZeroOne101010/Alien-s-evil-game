using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : EntityAttack
{

    public GameObject[] spikePrifab;
    public int countSpikes;
    public float forceShot;

    public int idAnimationAttack;

    public float timeReload;

    public Vector2 offsetShot;
    public float radiusShot;

    private EntityController entityController;
    private float timerReload;

    public override void attackStart()
    {
        base.attackStart();
        entityController = GetComponent<EntityController>();
    }

    public override void attackUpdate()
    {
        base.attackUpdate();
        timerReload--;
        if (timerReload < 0) timerReload = 0;
    }

    public override void attack(GameObject entity)
    {
        base.attack(entity);
        if (timerReload == 0)
        {
            float offsetAngle = (2 * Mathf.PI) / countSpikes;

            for (int x = 0; x < countSpikes; x++)
            {
                float angle = offsetAngle * x;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                int idPrifab = Random.Range(0, spikePrifab.Length);
                GameObject prifab = spikePrifab[idPrifab];

                GameObject spike = Instantiate(prifab, (Vector2)transform.position + offsetShot + direction * radiusShot, Quaternion.AngleAxis(angle / (Mathf.PI * 2) * 360, new Vector3(0, 0, 1)));

                BulletController bulletController = spike.GetComponent<BulletController>();
                bulletController.initBullet(entityController.teamId, direction, null, null);

            }
            timerReload = timeReload;
        }
    }


}
