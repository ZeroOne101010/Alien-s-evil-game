using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMelleAttak : MonoBehaviour
{

    public Collider2D[] attackTrigger;
    public bool attaking;
    public int idAttack = -1;
    private float timer;

    public string[] attackAnimationName;
    public float[] attackDamage;
    public float[] attackProbably;
    public float[] timeAttack;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer--;
        if (timer < 0) timer = 0;
        if(timer == 0)
        {
            if(idAttack != -1)
            {
                if(animator != null)
                animator.SetBool(attackAnimationName[idAttack], false);
                idAttack = -1;
            }
        }
    }

    public void activeRandomAttack()
    {
        int id = 0;
        for(int x = 0; x < attackProbably.Length; x++)
        {
            if(Random.Range(0.0000f, 1.0000f) < attackProbably[x])
            {
                id = x;
            }
        }
        activeAttack(id);
    }

    public void activeAttack(int id)
    {
        if (timer == 0)
        {
            idAttack = id;
            timer = timeAttack[id];
            if(animator != null)
            animator.SetBool(attackAnimationName[id], true);
        }

    }
}
