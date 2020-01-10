using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEntityMoveController : MonoBehaviour
{

    public float distanceToFindTarget;

    [HideInInspector]
    public GameObject target;

    private EntityController state;
    private EntityMove entityMoveController;

    void Start()
    {
        state = GetComponent<EntityController>();
        entityMoveController = GetComponent<EntityMove>();
    }

    void Update()
    {
        moveToTarget();
    }

    public GameObject getTarget()
    {
        GameObject target = null;
        GameObject[] allEntitys = GameObject.FindGameObjectsWithTag("Entity");
        List<GameObject> enemyEntity = new List<GameObject>();
        for(int x = 0; x < allEntitys.Length; x++)
        {
            EntityController state = allEntitys[x].GetComponent<EntityController>();
            if(this.state.teamId != state.teamId)
            {
                enemyEntity.Add(allEntitys[x]);
            }
        }

        for(int x = 0; x < enemyEntity.Count; x++)
        {
            float distance = Vector2.Distance(transform.position, enemyEntity[x].transform.position);
            if(distance < distanceToFindTarget)
            {
                target = enemyEntity[x];
            }
            break;
        }

        return target;
    }

    public void moveToTarget()
    {
        if(target != null)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance < distanceToFindTarget)
            {
                Vector2 direction = (Vector2)((target.transform.position - transform.position)).normalized;
                entityMoveController.movePerson(direction);
            }
            else
            {
                target = null;
            }
        }
        else
        {
            entityMoveController.stopMovePerson();
            target = getTarget();
        }
    }
}
