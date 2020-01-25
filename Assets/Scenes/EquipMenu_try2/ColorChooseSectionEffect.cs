using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChangeColorType
{
    initalColor,
    color
}
public class ColorChooseSectionEffect : SectionEffect
{
    public override void EffectStart()
    {
        base.EffectStart();
        if (GetComponent<kElementController>().selectedID == GetComponent<kElementController>().ID)
        {
            Effect();
        }

    }
    public override void EffectUpdate()
    {
        base.EffectUpdate();

    }
    public override void Effect()
    {
        base.Effect();
        ChangeColorForChilds(gameObject, ChangeColorType.color);
        print("k");
    }

    public override void DeEffect()
    {
        base.DeEffect();
        ChangeColorForChilds(gameObject, ChangeColorType.initalColor);
    }
    public void ChangeColor(GameObject obj, ChangeColorType colorType)
    {
        switch (colorType)
        {
            case ChangeColorType.initalColor:
                if (obj.GetComponent<ChangingColors>() != null)
                {
                    if (obj.GetComponent<Image>() != null)
                        obj.GetComponent<Image>().color = obj.GetComponent<ChangingColors>().initalColor;
                    if (obj.GetComponent<Text>() != null)
                        obj.GetComponent<Text>().color = obj.GetComponent<ChangingColors>().initalColor;
                }
                break;
            case ChangeColorType.color:
                if (obj.GetComponent<ChangingColors>() != null)
                {
                    if (obj.GetComponent<Image>() != null)
                        obj.GetComponent<Image>().color = obj.GetComponent<ChangingColors>().color;
                    if (obj.GetComponent<Text>() != null)
                        obj.GetComponent<Text>().color = obj.GetComponent<ChangingColors>().color;
                }
                break;
        }

    }
    public void ChangeColorForChilds(GameObject parent, ChangeColorType colorType)
    {
        ChangeColor(parent, colorType);
        if (parent.transform.childCount > 0)
        {
            foreach (Transform childChild in parent.transform)
            {
                ChangeColorForChilds(childChild.gameObject, colorType);
            }
        }
    }
}
