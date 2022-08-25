using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMover : MonoBehaviour
{
    public float s_speed;
    private bool s_isFacingRight = true;
    private float s_MovementInputDirectionX;
    private float s_MovementInputDirectionY;
    Rigidbody2D s_rb;
    Animator anim;
    private bool s_isWalking;
    public GameObject player;
    public Mover moverscript;

    // Start is called before the first frame update
    void Start()
    {
        s_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        moverscript = player.GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        s_CheckInput();
        s_CheckDirection();
        s_UpdateAnimations();
        s_poof();
    }
    private void FixedUpdate()
    {
        s_ApplyMovement();
    }
    private void s_CheckDirection()
    {
        if (s_isFacingRight && s_MovementInputDirectionX < 0)
        {
            s_Flip();
        }
        else if (!s_isFacingRight && s_MovementInputDirectionX > 0)
        {
            s_Flip();
        }
        s_CheckIfWalking();
    }

    private void s_CheckIfWalking()
    {
        if (s_rb.velocity.x != 0)
        {
            s_isWalking = true;
        }
        else
        {
            s_isWalking = false;
        }
    }
    private void s_UpdateAnimations()
    {
        anim.SetBool("s_isWalking", s_isWalking);
    }
    private void s_Flip()
    {
        s_isFacingRight = !s_isFacingRight;
        transform.Rotate(0, 180, 0);
    }
    private void s_CheckInput()
    {
        s_MovementInputDirectionX = Input.GetAxis("Horizontal");
        s_MovementInputDirectionY = Input.GetAxis("Vertical");
    }
    private void s_ApplyMovement()
    {
        s_rb.velocity = new Vector2(s_speed * s_MovementInputDirectionX, s_speed * s_MovementInputDirectionY);
    }
    private void s_poof()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("isHuman");
            if (player!=null)
            {
                moverscript.enabled = true;
            }
            else
            {
                player = GameObject.FindGameObjectWithTag("Player");
                moverscript = player.GetComponent<Mover>();
            }
            Destroy(this.gameObject,0.5f);
        }
    }
}
