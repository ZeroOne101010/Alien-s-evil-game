using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kElementController : MonoBehaviour
{
    [HideInInspector]
    public int selectedID;
    [HideInInspector]
    public int ID;
    void Start()
    {

    }
    void Update()
    {

    }
    public void ClickEffectsActivate()
    {
        SectionEffect[] clickEffects = GetComponents<SectionEffect>();
        for (int i = 0; i < clickEffects.Length; i++)
            clickEffects[i].Effect();
    }
}
