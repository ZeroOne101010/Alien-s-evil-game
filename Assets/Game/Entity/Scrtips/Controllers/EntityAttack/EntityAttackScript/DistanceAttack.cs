using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAttack : MonoBehaviour
{

    public float distanceToAttack = 1;
    public float damage;

    private EntityAttackController attackController;

    public void Start()
    {
        attackController = GetComponent<EntityAttackController>();
    }

    public void Update()
    {

    }

    public void checkToAttack()
    {
        
    }

}
