using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackController : MonoBehaviour
{

    public int attackTimeReload;

    private int attackTimerReload;

    [HideInInspector]
    public bool attackIsReloaded;
    [HideInInspector]
    public EntityAttack[] entityAttack;

    private EntityMoveController entityMoveController;

    void Start()
    {
        entityAttack = GetComponents<EntityAttack>();
        entityMoveController = GetComponent<EntityMoveController>();
        attackTimerReload = attackTimeReload;
        for(int x = 0; x < entityAttack.Length; x++)
        {
            entityAttack[x].attackStart();
        }
        entityStart();
    }

    void Update()
    {
        updateReloadTimer();
        entityUpdate();
        for (int x = 0;x < entityAttack.Length; x++)
        {
            entityAttack[x].attackUpdate();
        }
    }

    public virtual void entityStart()
    {

    }

    public virtual void entityUpdate()
    {

    }

    public void allAttack(GameObject entity)
    {
        for (int x = 0; x < entityAttack.Length; x++)
        {
            entityAttack[x].attack(entity);
        }
    }

    public void randomAttack(GameObject entity)
    {
        int id = Random.Range(0, entityAttack.Length);
        float probably = Random.Range(0.000f, 100.000f);
        for(int x = 0; x < entityAttack.Length; x++)
        {
            if (entityAttack[x].probablyChooseAttack > probably)
            {
                id = x;
                break;
            }
        }
        entityAttack[id].attack(entity);
    }

    public void attack(int id, GameObject entity)
    {
        entityAttack[id].attack(entity);
    }

    private void updateReloadTimer()
    {
        attackTimerReload--;
        if (attackTimerReload < 0) attackTimerReload = 0;
        if(attackTimerReload == 0)
        {
            attackIsReloaded = true;
        }
        else
        {
            attackIsReloaded = false;
        }
    }

    public void toReloadAttack()
    {
        attackTimerReload = attackTimeReload;
    }

}
