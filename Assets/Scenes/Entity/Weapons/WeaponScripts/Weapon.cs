using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{

    public IKeepWeapon weaponCarrier;
    public GameObject bulletPrifab;
    public float forceShot;
    public float time;
    private float timer;

    //protected RegistredItems registeryItems = GameObject.FindGameObjectWithTag("RegisteryManager").GetComponent<>;

    public GameObject item;

    public Vector2 offsetShotBullet;

    public Weapon(GameObject item)
    {
        this.item = item;
        weaponStart();
    }

    void onUpdate()
    {
        weaponUpdate();
    }

    public virtual void weaponStart()
    {

    }

    public virtual void weaponUpdate()
    {

    }

    public void takeWeapon(IKeepWeapon weaponCarrier)
    {
        weaponCarrier.addWeapon(this);
        this.weaponCarrier = weaponCarrier;
    }

    /*
     * Возвращает заспавненный предмет оружия
     */
    public GameObject dropWeapon()
    {
        weaponCarrier.dropWeapon(this);
        GameObject item = GameObject.Instantiate(this.item, weaponCarrier.getCarrierWeapon().transform.position + (Vector3)(weaponCarrier.getWeaponOffsetPosition()), this.item.transform.rotation);
        return item;
    }

    /*
     * Этот метод будет вызываться при выстреле оружия
     */
    public virtual void weaponShotEffect(GameObject bullet)
    {

    }


    public void shotBullet(Vector2 direction)
    {
            timer--;
            if (timer < 0) timer = 0;
            if (timer == 0)
            {
                timer = time;
                GameObject bullet = null;
                bullet = GameObject.Instantiate(bulletPrifab, (Vector3)(offsetShotBullet) + weaponCarrier.getCarrierWeapon().transform.position + (Vector3)(weaponCarrier.getWeaponOffsetPosition()), Quaternion.Euler(direction.x, direction.y, 0));
                bullet.GetComponent<Rigidbody2D>().velocity = direction * forceShot;
                weaponShotEffect(bullet);
            }
    }
}
