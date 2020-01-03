using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void WeaponImplementation(float damage, GameObject bulletType, GameObject weapon);
/* Чтобы добавить оружие нужно добавить в список делегатов weaponImplementation метод реализации оружия:
 * weaponImplementation.Add(dullImplementation);
 * Урон будет браться из скрипта WeaponWork, который должен находится на оружии
*/
public class RegistoredWeapons : MonoBehaviour
{
    public GameObject dull;
    public GameObject pull;
    public GameObject bigDull;

    public static List<WeaponImplementation> weaponImplementation = new List<WeaponImplementation>();
    public void Start()
    {
        weaponImplementation.Add(dullImplementation); // 0 - dull
        weaponImplementation.Add(pullImplementation); // 1 - pull
        weaponImplementation.Add(bigDullImplementation); // 2 - bigDull
    }
    static public void dullImplementation(float damage, GameObject bulletType, GameObject weapon) // Реализация функционала оружия dull
    {
        basicBullet(damage, bulletType, weapon);
    }
    static public void pullImplementation(float damage, GameObject bulletType, GameObject weapon) // Реализация функционала оружия pull
    {
        print("pull" + damage);
    }
    static public void bigDullImplementation(float damage, GameObject bulletType, GameObject weapon) // Реализация функционала оружия bigDull
    {
        print("bigDull " + damage);
    }
    static public void basicBullet(float damage, GameObject bulletType, GameObject weapon)
    {
        bulletType = Instantiate(bulletType, weapon.transform.position, Quaternion.identity);
        bulletType.transform.rotation = weapon.transform.rotation; // Меняю ротейшен пули
        int dir = 0;
        if(weapon.transform.rotation.y > 0)
            dir = -1;
        else if (weapon.transform.rotation.y <= 0)
            dir = 1;

        bulletType.transform.position += new Vector3(dir, 0, 0); // Выдвегаю его из персонажа, чтоб перс урон не получал от своих пуль
        if (bulletType.GetComponent<BulletWork>() != null)
        {
            bulletType.GetComponent<BulletWork>().damage = damage;
            bulletType.GetComponent<BulletWork>().diraction = new Vector3(dir, 0, 0);
        }
    }
}
