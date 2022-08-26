using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float MovementInputDirection;
    Rigidbody2D rb;
    public float speed=5f;
    [HideInInspector]
    public bool isFacingRight = true;
    public float JumpForce = 60f;
    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask GroundLayer;
    bool isGrounded;
    bool canJump;
    public bool isWalking;
    [HideInInspector]
    public Animator anim;
    bool isInAstral;
    public GameObject Shadow;
    [HideInInspector]
    public static Mover instance;
    public Transform ShadowSpawner;
    public bool canWalk;
    public bool canFlip;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canWalk = true;
        canFlip = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckDirection();
        UpdateAnimations();
        CheckIfcanJump();
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("Astral", isInAstral);
    }

    private void CheckIfcanJump()
    {
        if (isGrounded && rb.velocity.y <= 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void CheckDirection()
    {
        if (isFacingRight && MovementInputDirection < 0 && canFlip)
        {
            Flip();
        }
        else if (!isFacingRight && MovementInputDirection > 0 && canFlip)
        {
            Flip();
        }
        CheckIfWalking();
    }

    private void CheckIfWalking()
    {
        if (rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);

    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }
    private void CheckInput()
    {
        MovementInputDirection = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.X) && isGrounded && isInAstral==false)
        {
            isInAstral = true;
            SpawnShadow();
            this.enabled = false;
        }
        else
        {
            isInAstral = false;
        }
    }

    private void SpawnShadow()
    {
        GameObject s_Shadow = Instantiate(Shadow,ShadowSpawner);
        if(gameObject.transform.rotation.y==180)
        {
            s_Shadow.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            s_Shadow.GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    private void Jump()
    {
        if(canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }

    private void ApplyMovement()
    {
        if(canWalk)
        {
            rb.velocity = new Vector2(speed*MovementInputDirection,rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);
    }
    public void Deactivate()
    {
        canWalk = false;
    }
    public void Activate()
    {
        canWalk = true;
    }
    public void DeactivateFlip()
    {
        canFlip = false;
    }
    public void ActivateFlip()
    {
        canFlip = true;
    }
}
