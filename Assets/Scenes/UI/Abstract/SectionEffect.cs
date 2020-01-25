using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SectionEffect : MonoBehaviour
{
    void Start()
    {
        EffectStart();
    }

    void Update()
    {
        EffectUpdate();
    }
    public virtual void EffectStart()
    {

    }
    public virtual void EffectUpdate()
    {

    }
    public virtual void Effect()
    {

    }
    public virtual void DeEffect()
    {

    }

}
