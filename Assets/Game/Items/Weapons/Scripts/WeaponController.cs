using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    private WeaponShot[] weaponShot;
    public Vector2 offsetShot;

    [HideInInspector]
    public GameObject keepedEntity;

    [HideInInspector]
    public bool canTakeItem;

    public float timeReload;

    private float timerReload;

    void Start()
    {
        canTakeItem = true;
        weaponShot = GetComponents<WeaponShot>();
    }

    void Update()
    {
        timerReload--;
        if (timerReload < 0) timerReload = 0;
    }

    public void takeTheWeapon(GameObject keepedEntity)
    {
        this.keepedEntity = keepedEntity;
    }

    public void shotEffect()
    {
        ShotEffect[] effect = GetComponents<ShotEffect>();
        EntityMove entityMove = keepedEntity.GetComponent<EntityMove>();
        bool isRight = entityMove.isRight;
        Vector2 offset = isRight ? offsetShot : -offsetShot;
        for (int x = 0; x < effect.Length; x++)
        {
            effect[x].effect(offset);
        }
    }

    public void shot()
    {
        if (timerReload == 0)
        {
            shotEffect();
            EntityMove entityMove = keepedEntity.GetComponent<EntityMove>();
            bool isRight = entityMove.isRight;
            Vector2 offset = isRight ? offsetShot : new Vector2(-offsetShot.x, offsetShot.y);
            for (int x = 0; x < weaponShot.Length; x++)
            {
                weaponShot[x].shot(offset);
            }
            timerReload = timeReload;
        }
    }
}
