using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveToObject : MonoBehaviour
{

    public GameObject trackedObj;
    public string tag;
    private float trackSpeed;
    public bool lookAtRight;
    public float offestToObj;
    private Animator animator;
    private Rigidbody2D rigid;

    public void Start()
    {
        tag = "Player";
        trackedObj = GameObject.FindWithTag(tag);
        animator = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        trackSpeed = GetComponent<Entity>().speedMove;
    }

    public void Update()
    {
        Tracking("MoveTrackObject", offestToObj);
    }

    public void Tracking(string moveAnimationBool, float offestToObj)
    {
        float trackedObjWidth = trackedObj.GetComponent<SpriteRenderer>().bounds.max.x - trackedObj.GetComponent<SpriteRenderer>().bounds.min.x;

        if (transform.position.x > trackedObj.transform.position.x - (trackedObjWidth / 2) - offestToObj & transform.position.x < trackedObj.transform.position.x + (trackedObjWidth / 2) + offestToObj)
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            if (trackedObj.transform.position.x > transform.position.x)
                gameObject.transform.localScale = new Vector3(-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            if (trackedObj.transform.position.x < transform.position.x)
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
                gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                if (animator != null)
                {
                    animator.SetBool(moveAnimationBool, true);
                    animator.speed = trackSpeed / 5;
                }
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
                gameObject.transform.localScale = new Vector3(-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                if (animator != null)
                {
                    animator.SetBool(moveAnimationBool, true);
                    animator.speed = trackSpeed / 5;
                }
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
