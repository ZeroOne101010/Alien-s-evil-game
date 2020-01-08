using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMelleAttak : AITask
{

    public GameObject gameObject;

    public bool attacking;

    public int attackId;

    public string[] nameAttackAnimation;
    public float[] timeAttack;
    public float[] attackDamage;
    public float[] probablyAttack;

    public float timeBetweenAttack;
    public float timer2;

    public List<Entity> alreadyAttackingEntity;

    private float timer;
    public bool k;
    public bool k2;
    private Animator animator;

    public AIMelleAttak(GameObject gameObject, string[] nameAttackAnimation, float[] timeAttack, float[] attackDamage, float[] probablyAttack, float timeBetweenAttack)
    {
        alreadyAttackingEntity = new List<Entity>();
        this.gameObject = gameObject;
        this.nameAttackAnimation = nameAttackAnimation;
        this.timeAttack = timeAttack;
        this.probablyAttack = probablyAttack;
        this.attackDamage = attackDamage;
        this.timeBetweenAttack = timeBetweenAttack;
        animator = gameObject.GetComponent<Animator>();

    }

    public override void updateTask()
    {
        updateAttack();
    }

    public void activeAttacking()
    {
        if (!attacking)
        {
            activeRandomAttack();
            attacking = true;
        }
    }

    public void attack(int id)
    {
        attackId = id;
        if(animator != null)
        {
            animator.SetBool(nameAttackAnimation[attackId], true);
        }

    }

    public void activeRandomAttack()
    {
        int id = 0;
        for (int x = 0; x < probablyAttack.Length; x++)
        {
            if (Random.Range(0.0000f, 100.0000f) < probablyAttack[x])
            {
                id = x;
            }
        }
        attack(id);
        timer = timeAttack[attackId];
    }

    public void updateAttack()
    {
        if (attacking)
        {
            if (!k)
            {
                k2 = true;
                timer--;
                if (timer < 0) timer = 0;
                if (timer == 0)
                {
                    timer = timeBetweenAttack;
                    k = true;
                }
            }
            else
            {
                k2 = false;
                timer--;
                if (timer < 0) timer = 0;
                if(timer == 0)
                {
                    k = false;
                    attacking = false;
                    alreadyAttackingEntity = new List<Entity>();
                    if (animator != null)
                    {
                        animator.SetBool(nameAttackAnimation[attackId], false);
                    }
                }

            }
        }

        //timer--;
        //if (timer < 0) timer = 0;
        //if (!k2)
        //{
        //    if (!k)
        //    {
        //        activeRandomAttack();
        //        timer = timeAttack[attackId];
        //        k = true;
        //    }
        //    else
        //    {
        //        if (timer == 0)
        //        {
        //            k2 = true;
        //            timer = timeBetweenAttack;
        //            k = false;
        //            attacking = false;
        //            alreadyAttackingEntity = new List<Entity>();
        //            if (animator != null)
        //            {
        //                animator.SetBool(nameAttackAnimation[attackId], false);
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    if (timer == 0)
        //    {
        //        k2 = false;
        //    }
        //}



        //timerAttack--;
        //if (timerAttack < 0) timerAttack = 0;

        //if (timerAttack == 0)
        //{
        //    activeRandomAttack();
        //    if (timerBetweenAttack == 0)
        //    {
        //        timerBetweenAttack = timeBetweenAttack;
        //    }

        //    timerBetweenAttack--;
        //    if (timerBetweenAttack < 0) timerBetweenAttack = 0;

        //    if (timerBetweenAttack == 0)
        //    {
        //        timerAttack = timeAttack[attackId];
        //        attacking = false;
        //        if (animator != null)
        //        {
        //            animator.SetBool(nameAttackAnimation[attackId], false);
        //        }
        //    }

        //}
    }
}















//public GameObject gameObject;

//public Collider2D[] attackTrigger;
//public bool attaking;
//public int idAttack = -1;
//private float timer;

//public float timeBetweenAttack = 100;
//public string[] attackAnimationName;
//public float[] attackDamage;
//public float[] attackProbably;
//public float[] timeAttack;

//private float timerBetweenAttack = 100;

//private Animator animator;
//private List<Entity> alreadyAttackedEntity;

//public AIMelleAttak(GameObject gameObject, Collider2D[] attackTrigger, string[] attackAnimationName, float[] attackDamage, float[] attackProbably, float[] timeAttack, float timeBetweenAttack)
//{
//    this.gameObject = gameObject;
//    this.attackTrigger = attackTrigger;
//    this.attackAnimationName = attackAnimationName;
//    this.attackDamage = attackDamage;
//    this.attackProbably = attackProbably;
//    this.timeAttack = timeAttack;
//    this.timeBetweenAttack = timeBetweenAttack;
//    timerBetweenAttack = timeBetweenAttack;

//    animator = gameObject.GetComponent<Animator>();
//}


//public AIMelleAttak(GameObject gameObject, Collider2D[] attackTrigger, string[] attackAnimationName, float[] attackDamage, float[] attackProbably, float[] timeAttack)
//{
//    this.gameObject = gameObject;
//    this.attackTrigger = attackTrigger;
//    this.attackAnimationName = attackAnimationName;
//    this.attackDamage = attackDamage;
//    this.attackProbably = attackProbably;
//    this.timeAttack = timeAttack;

//    animator = gameObject.GetComponent<Animator>();
//}

//public override void updateTask()
//{
//    timerBetweenAttack--;
//    if (timerBetweenAttack < 0) timeBetweenAttack = 0;
//    if (timeBetweenAttack == 0)
//    {
//        activeRandomAttack();
//        attaking = true;
//        timer--;
//        if (timer < 0) timer = 0;
//        if (timer == 0)
//        {
//            if (idAttack != -1)
//            {
//                timer = timeAttack[idAttack];
//                timerBetweenAttack = timeBetweenAttack;
//            }
//        }
//    }
//    else
//    {
//        attaking = false;
//        idAttack = -1;
//    }
//}

//public void activeRandomAttack()
//{
//    if (attaking)
//    {
//        int id = 0;
//        for (int x = 0; x < attackProbably.Length; x++)
//        {
//            if (Random.Range(0.0000f, 1.0000f) < attackProbably[x])
//            {
//                id = x;
//            }
//        }
//        activeAttack(id);
//    }
//}

//public void activeAttack(int id)
//{
//    if (timer == 0)
//    {
//        idAttack = id;
//        timer = timeAttack[id];
//        if (animator != null)
//            animator.SetBool(attackAnimationName[id], true);
//    }

//}

//public void attackEntity(Entity entity)
//{
//    if (entity != null)
//    {
//        if (attaking)
//        {
//            if (!alreadyAttackedEntity.Contains(entity))
//            {
//                if (idAttack != -1)
//                {
//                    entity.getDamage(attackDamage[idAttack]);
//                    alreadyAttackedEntity.Add(entity);
//                }
//            }
//        }
//    }
//}
//}
