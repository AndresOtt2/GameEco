using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveN2 : MonoBehaviour
{
    //Movimiento eje horizontal
    public float runSpeed = 2;

    //Salto
    public float jumSpeed = 3;

    Rigidbody2D rb2D;

    BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    //Salto mejorado, depende de que tanto se pulse el 'space'
    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey("d") || Input.GetKey("right")){
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if(Input.GetKey("a") || Input.GetKey("left")){
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else{
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        if(Input.GetKey("space") && isGrounded()){
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumSpeed);
        }

        if(isGrounded() == false){
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if(isGrounded()){
            animator.SetBool("Jump", false);
        }

        if(betterJump){
            if(rb2D.velocity.y < 0){
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if(rb2D.velocity.y > 0 && !Input.GetKey("space")){
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
        

    }

    private bool isGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
