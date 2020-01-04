using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMonsterAttack : AITask
{
    public GameObject gameObject;

    private Animator animator;
    public GameObject obj;
    public GameObject hitBox;
    public float offestToObj;
    public float attackSpeed;
    private float timer;
    private bool isAttack;

    public AIMonsterAttack(GameObject gameObject)
    {
        this.gameObject = gameObject;
        animator = gameObject.GetComponent<Animator>();
        gameObject.tag = "Player";
        obj = GameObject.FindWithTag(gameObject.tag);
    }

    public override void updateTask()
    {
        AttackHero("Attack", offestToObj);
    }

    public void AttackHero(string attackAnimationBool, float offset)
    {
        animator.speed = attackSpeed;
        float objWidth = obj.GetComponent<Collider2D>().bounds.max.x - obj.GetComponent<Collider2D>().bounds.min.x;
        if(gameObject.transform.position.x > obj.transform.position.x - (objWidth / 2) - offset & gameObject.transform.position.x < obj.transform.position.x + (objWidth / 2) + offset)
        {
            if (animator != null)
                animator.SetBool(attackAnimationBool, true);
                //print(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
                hitBox.SetActive(true);
        }
        else
        {
            if (animator != null)
                animator.SetBool(attackAnimationBool, false);
        }
    }

}
