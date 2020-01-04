using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveToObject : AITask
{

    public GameObject gameObject;

    public GameObject trackedObj;
    public string tag;
    public string nameOfAnimation;
    private float trackSpeed;
    public bool lookAtRight;
    public float offestToObj;
    private Animator animator;
    private Rigidbody2D rigid;

    public AIMoveToObject(GameObject gameObject, string tag)
    {
        this.gameObject = gameObject;
        gameObject.tag = tag;
        trackedObj = GameObject.FindWithTag(tag);
        animator = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        trackSpeed = gameObject.GetComponent<Entity>().speedMove;
    }

    public override void updateTask()
    {
        Tracking(nameOfAnimation, offestToObj);
    }

    public void Tracking(string moveAnimationBool, float offestToObj)
    {
        float trackedObjWidth = trackedObj.GetComponent<Collider2D>().bounds.max.x - trackedObj.GetComponent<Collider2D>().bounds.min.x;
        

        if (gameObject.transform.position.x > trackedObj.transform.position.x - (trackedObjWidth / 2) - offestToObj & gameObject.transform.position.x < trackedObj.transform.position.x + (trackedObjWidth / 2) + offestToObj)
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            if (trackedObj.transform.position.x > gameObject.transform.position.x)
                gameObject.transform.localScale = new Vector3(-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            if (trackedObj.transform.position.x < gameObject.transform.position.x)
                gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            if (animator != null)
                animator.SetBool(moveAnimationBool, false);
        }
        else
        {
            if (gameObject.transform.position.x > trackedObj.transform.position.x)
            {
                if (rigid != null)
                {
                    rigid.velocity = new Vector3(-trackSpeed, rigid.velocity.y);
                }
                else
                {
                    gameObject.transform.position += new Vector3(-trackSpeed, 0);
                }
                if (animator != null)
                {
                    animator.SetBool(moveAnimationBool, true);
                    animator.speed = trackSpeed / 5;
                }
                gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                lookAtRight = false;
            }
            else if (gameObject.transform.position.x < trackedObj.transform.position.x)
            {
                if (rigid != null)
                {
                    rigid.velocity = new Vector3(trackSpeed, rigid.velocity.y);
                }
                else
                {
                    gameObject.transform.position += new Vector3(trackSpeed, 0);
                }
                if (animator != null)
                {
                    animator.SetBool(moveAnimationBool, true);
                    animator.speed = trackSpeed / 5;
                }
                gameObject.transform.localScale = new Vector3(-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                lookAtRight = true;
            }
            else
            {
                if (animator != null)
                    animator.SetBool(moveAnimationBool, false);
            }
        }
    }
}
