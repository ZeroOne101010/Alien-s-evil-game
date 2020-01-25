using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    public int teamId = -1;
    public float health = 100;

    [HideInInspector]
    public bool isDeath;

    public int idAnimationAttack;

    private EntityDeathEffect[] deathEffect;
    protected EntityMoveController entityMoveController;

    void Start()
    {
        entityMoveController = GetComponent<EntityMoveController>();
        entityStart();
    }

    void Update()
    {
        if (isDeath)
        {
            for (int x = 0; x < deathEffect.Length; x++)
            {
                deathEffect[x].effectUpdate();
            }
        }
        else
        {
            entityUpdate();
        }
    }

    public virtual void entityStart()
    {

    }

    public virtual void entityUpdate()
    {

    }

    public void death()
    {
        deathEffect = GetComponents<EntityDeathEffect>();
        entityMoveController.stopMovePerson();
        for (int x = 0; x < deathEffect.Length; x++)
        {
            deathEffect[x].effectStart();
        }
        isDeath = true;


        //MonoBehaviour[] component = GetComponents<MonoBehaviour>();
        //for (int x = 0; x < component.Length; x++)
        //{
        //    if(!(component[x] is EntityController) && !(component[x] is EntityDeathEffect) && !(component[x] is EntityAnimation) && !(component[x] is AnimationController))
        //    {
        //        component[x].enabled = false;
        //    }
        //}

    }

    public void setDamage(float damage)
    {
        if (!isDeath)
        {
            health -= damage;
            if (health <= 0)
            {
                death();
            }
        }
    }
}
