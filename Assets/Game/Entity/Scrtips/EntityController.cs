using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public int teamId = -1;
    public float health = 100;

    [HideInInspector]
    public bool isDeath;

    private EntityDeathEffect[] effect;

    void Start()
    {

    }

    void Update()
    {
        if (isDeath)
        {
            for (int x = 0; x < effect.Length; x++)
            {
                effect[x].effectUpdate();
            }
        }
    }

    public void death()
    {
        effect = GetComponents<EntityDeathEffect>();
        for (int x = 0; x < effect.Length; x++)
        {
            effect[x].effectStart();
        }
        isDeath = true;

        MonoBehaviour[] component = GetComponents<MonoBehaviour>();
        for (int x = 0; x < component.Length; x++)
        {
            if(!(component[x] is EntityController) && !(component[x] is EntityDeathEffect))
            {
                component[x].enabled = false;
            }
        }

    }

    public void setDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            death();
        }
    }
}
