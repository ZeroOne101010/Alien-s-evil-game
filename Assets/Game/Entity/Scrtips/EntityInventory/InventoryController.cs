using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryController : MonoBehaviour
{
    [HideInInspector]
    public Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        controllerStart();
    }

    void Update()
    {
        controllerUpdate();
    }

    public virtual void controllerStart()
    {

    }

    public virtual void controllerUpdate()
    {

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            if (inventory.canAddItems)
            {
                if (!inventory.isFull())
                {
                    WeaponController weaponController = collision.gameObject.GetComponent<WeaponController>();
                    if (weaponController != null)
                    {
                        if (weaponController.canTakeItem)
                        {
                            inventory.addItem(collision.gameObject);
                            weaponController.takeTheWeapon(gameObject);
                            collision.gameObject.SetActive(false);
                        }
                    }
                    else
                    {
                        inventory.addItem(collision.gameObject);
                        collision.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
