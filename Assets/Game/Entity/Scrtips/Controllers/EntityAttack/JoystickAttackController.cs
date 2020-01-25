using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickAttackController : EntityAttackController
{
    public GameObject attackButton;

    private Button button;

    public override void entityStart()
    {
        base.entityStart();
        button = attackButton.GetComponent<Button>();
        button.onClick.AddListener(buttonAttack);
        //button.OnPointerClick();
    }

    public void buttonAttack()
    {
        attack(0, null);
    }


    public override void entityUpdate()
    {
        base.entityUpdate();
    }
}
