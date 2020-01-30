using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowerHeathBar : MonoBehaviour
{

    public Slider heathbar;

    private EntityController entityController;
    private float maxHeath;

    void Start()
    {
        entityController = GetComponent<EntityController>();
        maxHeath = entityController.health;
    }

    void Update()
    {
        heathbar.value = entityController.health / maxHeath;
    }
}
