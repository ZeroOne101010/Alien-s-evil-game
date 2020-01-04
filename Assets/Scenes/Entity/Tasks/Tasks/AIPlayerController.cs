using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AIPlayerController : AITask
{

    public GameObject gameObject;

    private float speed;
    public float jumpForce;
    public GameObject joystick;
    public Button jumpButton;
    private Rigidbody2D rigid;
    public bool isRun = false;
    public Animator animator;
    public string nameAnimRun;
    public string nameAnimVelocity;
    public string groundAnimValue;

    public AIPlayerController(GameObject gameObject, GameObject joystick, Button jumpButton)
    {
        this.gameObject = gameObject;

        this.joystick = joystick;
        this.jumpButton = jumpButton;
        rigid = gameObject.GetComponent<Rigidbody2D>();
        speed = gameObject.GetComponent<Entity>().speedMove;
        jumpForce = gameObject.GetComponent<Entity>().jumpForce;
        if (gameObject.GetComponent<Animator>() != null) 
            animator = gameObject.GetComponent<Animator>();
        jumpButton.onClick.AddListener(jump);
    }

    public AIPlayerController(GameObject gameObject, GameObject joystick)
    {
        this.gameObject = gameObject;

        this.joystick = joystick;
        rigid = gameObject.GetComponent<Rigidbody2D>();
        speed = gameObject.GetComponent<Entity>().speedMove;
        jumpForce = gameObject.GetComponent<Entity>().jumpForce;
        if (gameObject.GetComponent<Animator>() != null)
            animator = gameObject.GetComponent<Animator>();
    }

    public override void updateTask()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        if (gameObject.GetComponent<Animator>() != null)
            animator.SetBool(nameAnimRun, isRun);
        if(jumpButton != null)
        keyJump();
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            
            if (rigid != null)
            {
                rigid.velocity = new Vector2(speed, rigid.velocity.y);          
            }
            else
            {
                gameObject.transform.position += new Vector3(speed, 0, 0);
                
            }
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            isRun = true;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            
            if (rigid != null)
            {
                rigid.velocity = new Vector2(-speed, rigid.velocity.y);
                
            }
            else
            {
                
                gameObject.transform.position += new Vector3(-speed, 0, 0);
            }
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            isRun = true;
        }
        else if (joystick != null & joystick.GetComponent<JoyStick>().inputVector.x != 0)
        {
            if (rigid != null)
            {
                rigid.velocity = new Vector2(joystick.GetComponent<JoyStick>().inputVector.x * speed, rigid.velocity.y);
            }
            else
                gameObject.transform.position += new Vector3(-speed, 0, 0);
            if (rigid.velocity.x > 0.1f)
            {
                gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                isRun = true;
            }

            else if (rigid.velocity.x < -0.1f)
            {
                gameObject.transform.localScale = new Vector3(-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
               isRun = true;
            }
        }
        else
        {
            if (rigid != null)
            {
                //if (rigid.velocity.y == 0)
                //{
                    rigid.velocity = new Vector2(0, rigid.velocity.y);
                //}
            }
            isRun = false;
        }
    }

    public void keyJump()
    {
        if (rigid != null)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                jump();
            }
        }

        if (animator != null & rigid != null)
        {
            if (rigid.velocity.y == 0)
                animator.SetBool(groundAnimValue, true);
            else
                animator.SetBool(groundAnimValue, false);
            animator.SetFloat(nameAnimVelocity, rigid.velocity.y);
        }

    }

    public void jump()
    {
        if (rigid != null)
        {
            if (rigid.velocity.y == 0)
            {
                rigid.velocity += new Vector2(0, jumpForce);
            }
        }
        else
        {
            gameObject.transform.position += new Vector3(0, jumpForce, 0);
        }

        if (animator != null & rigid != null)
        {
            if (rigid.velocity.y == 0)
                animator.SetBool(groundAnimValue, true);
            else
                animator.SetBool(groundAnimValue, false);
            animator.SetFloat(nameAnimVelocity, rigid.velocity.y);
        }
               
    }
}
