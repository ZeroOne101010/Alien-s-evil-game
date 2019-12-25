using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMonsterAttack : MonoBehaviour
{
    private Animator animator;
    public GameObject obj;
    public GameObject hitBox;
    public float offestToObj;
    public float attackSpeed;
    private float timer;
    private bool isAttack;
    void Start()
    {
        //hitBox.SetActive(false);
        animator = gameObject.GetComponent<Animator>();
        tag = "Player";
        obj = GameObject.FindWithTag(tag);
    }

    void Update()
    {
        AttackHero("Attack", offestToObj);
    }
    public void AttackHero(string attackAnimationBool, float offset)
    {
        animator.speed = attackSpeed;
        float objWidth = obj.GetComponent<Collider2D>().bounds.max.x - obj.GetComponent<Collider2D>().bounds.min.x;
        if(transform.position.x > obj.transform.position.x - (objWidth / 2) - offset & transform.position.x < obj.transform.position.x + (objWidth / 2) + offset)
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
