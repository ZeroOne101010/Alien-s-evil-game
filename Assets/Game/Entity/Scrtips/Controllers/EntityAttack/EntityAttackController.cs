using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackController : MonoBehaviour
{
    [HideInInspector]
    public EntityAttack[] entityAttack;

    void Start()
    {
        entityAttack = GetComponents<EntityAttack>();
        for(int x = 0; x < entityAttack.Length; x++)
        {
            entityAttack[x].attackStart();
        }
    }

    void Update()
    {
        for(int x = 0;x < entityAttack.Length; x++)
        {
            entityAttack[x].attackUpdate();
        }
    }


    public void attack(GameObject entity)
    {
        for(int x = 0; x < entityAttack.Length; x++)
        {
            entityAttack[x].attack(entity);
        }
    }

}
