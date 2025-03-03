using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float a =1;
    PlayerControls controls;
    float direction = 0;
    public  float speed = 450;
    public Rigidbody2D playerRB;
    public Animator animator;
   public bool isFacingRight = true;

    public float jumpForce = 10;
    public bool isGrounded;
    int numberOfJumps =0;
    public Transform groundedCheck;
    public LayerMask groundLayer;
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
        controls.Land.Jump.performed += ctx => Jump();
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundedCheck.position, 0.1f, groundLayer);
            animator.SetBool("isGrounded", isGrounded);
        
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
     
        animator.SetFloat("speed", Mathf.Abs(direction));

        if(isFacingRight && direction <0 || !isFacingRight && direction >0)
            Flip(); 

    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
       if(isFacingRight)
        {
            transform.localPosition = new Vector2(transform.localPosition.x - a, transform.localPosition.y);
        }
        if (!isFacingRight)
        {
            transform.localPosition = new Vector2(transform.localPosition.x + a, transform.localPosition.y);
        }


        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    
    }
    void Jump()
    {
        if(isGrounded && playerRB!= null)
        {
            numberOfJumps = 0;
         AudioManager.instance.Play("jump");
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;
        }
        else
        {
            if(numberOfJumps == 1 && playerRB != null)
            {
               AudioManager.instance.Play("jump2");
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
            }
        }

    }
        }
