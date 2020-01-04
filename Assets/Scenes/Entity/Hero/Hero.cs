using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : Entity
{
    public Button jumpButton;
    public GameObject joystick;
    public GameObject weaponSlot1;
    public GameObject weaponSlot2;

    [HideInInspector]
    public Vector3 weaponOffset;

    [HideInInspector]
    private float maxHeath;

    public Slider slide;

    public override void entityStart()
    {
        jumpForce = 20;
        health = 200;
        maxHeath = health;
        weaponOffset = new Vector3(0.17f, -0.75f, 0);
        addTask(new AIPlayerController(gameObject, joystick, jumpButton));
        addTask(new AITakeAWeapon(gameObject, weaponSlot1, weaponSlot2, weaponOffset));

        base.entityStart();
    }

    public override void entityUpdate()
    {
        slide.value = GetComponent<Entity>().health / maxHeath * 100;
        base.entityUpdate();
    }

}
