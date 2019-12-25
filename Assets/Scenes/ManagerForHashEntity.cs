using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerForHashEntity : MonoBehaviour
{


    public List<Entity> entity;

    void Start()
    {

    }

    void Update()
    {

    }

    public void addEntity(Entity entity)
    {
        this.entity.Add(entity);
    }

    public void removeEntity(Entity entity)
    {
         this.entity.Remove(entity);
    }
}
