using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void WeaponImplementation(float damage);
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
    static public void dullImplementation(float damage) // Реализация функционала оружия dull
    {
        print("dull " + damage);
    }
    static public void pullImplementation(float damage) // Реализация функционала оружия pull
    {
        print("pull" + damage);
    }
    static public void bigDullImplementation(float damage) // Реализация функционала оружия bigDull
    {
        print("bigDull " + damage);
    }
}
