using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTag : MonoBehaviour
{

    public string tag;
    public float maxDistance;
    public float force;
    public float maxForce;
    public float KDistanceForce = 0.2f;

    private GameObject target;
    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(target != null)
        {
            float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
            if (distanceToTarget < maxDistance)
            {
                float forceMove = force / ((distanceToTarget * distanceToTarget) * KDistanceForce);
                if (forceMove > maxForce) forceMove = maxForce;
                Vector2 direction = (target.transform.position - transform.position).normalized;
                rigid.AddForce(direction * forceMove);
            }
            else
            {
                findTarget();
            }
        }
        else
        {
            findTarget();
        }
    }


    public void findTarget()
    {
        target = null;
        GameObject[] entity = GameObject.FindGameObjectsWithTag(tag);
        for(int x = 0; x < entity.Length; x++)
        {
            EntityController entityController = entity[x].GetComponent<EntityController>();
            if (entityController is IMathedController)
            {
                float distance = Vector2.Distance(transform.position, entity[x].transform.position);
                if (distance < maxDistance)
                {
                    target = entity[x];
                    break;
                }
            }
        }
    }
}
