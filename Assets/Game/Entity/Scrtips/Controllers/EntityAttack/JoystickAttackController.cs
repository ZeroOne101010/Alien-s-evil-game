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
        if (attackButton != null)
        {
            button = attackButton.GetComponent<Button>();
            button.onClick.AddListener(buttonAttack);
        }
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
