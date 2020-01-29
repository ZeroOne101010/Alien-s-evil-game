using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeShot : MeleeShot
{

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
        activeAnimationShot();
        GameObject[] entity = GameObject.FindGameObjectsWithTag("Entity");
        List<GameObject> canGetDamageEntity = new List<GameObject>();
        float distance = 0;
        for(int x = 0; x < entity.Length; x++)
        {
            if (entity[x].GetComponent<EntityController>().teamId != getTeamId())
            {
                distance = Vector2.Distance(transform.position, entity[x].transform.position);
                if(distance < rangeAttack)
                {
                    canGetDamageEntity.Add(entity[x]);
                }
            }
        }
        for(int x = 0; x < canGetDamageEntity.Count; x++)
        {
            EntityController entityController = canGetDamageEntity[x].GetComponent<EntityController>();
            entityController.setDamage(damage);
        }
    }
}
