using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponShot : MonoBehaviour
{

    public string nameAnimationShot = "Range";
    public string[] nameAnimationOther;
    private Animator personAnimator;

    void Start()
    {
        startWeaponShot();
    }

    void Update()
    {
        updateWeaponShot();
    }

    public virtual void startWeaponShot()
    {

    }

    public virtual void updateWeaponShot()
    {

    }

    public void activeAnimation(string name)
    {
        GameObject entity = getKeepedEntity();
        if(entity != null)
        {
            entity.GetComponent<EntityAttack>().activeAttackAnimation(name);
        }
    }

    public void activeAnimationShot()
    {
        activeAnimation(nameAnimationShot);
    }

    public abstract void shot(Vector3 offsetShot);

    public int getTeamId()
    {
        EntityController entity = GetComponent<WeaponController>().keepedEntity.GetComponent<EntityController>();
        return entity.teamId;
    }

    public EntityController getEntityController()
    {
        return GetComponent<WeaponController>().keepedEntity.GetComponent<EntityController>(); ;
    }

    public GameObject getKeepedEntity()
    {
        return GetComponent<WeaponController>().keepedEntity;
    }

}
