using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerScript : MonoBehaviour
{
    PhotonView view;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 20f;
    [SerializeField] public float swimSpeed = 5f;
    [SerializeField] public float swimJumpForce = 100f;
    [SerializeField] private float waterJumpCooldown = 1f; // Cooldown duration after leaving water
    private float waterJumpCooldownTimer = 0f; // Timer for tracking the cooldown

    [Header("Collision info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask isGround;
    [SerializeField] private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isSwimming = false;
    private bool isFalling = false;

    [SerializeField] private LayerMask playerLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if(view.IsMine){
            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            float verticalVelocity = rb.velocity.y;
            CollisionCheck();
            if (isSwimming)
            {
                rb.velocity = new Vector2(horizontalMovement * swimSpeed, Input.GetAxis("Vertical") * swimSpeed);
            }
            else
            {
                rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
            }

            if (horizontalMovement != 0f)
            {
                animator.SetBool("isMoving", true);
                transform.localScale = new Vector3(Mathf.Sign(horizontalMovement), 1f, 1f);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
            if (!isSwimming) {
                if (verticalVelocity > 0.1) {
                    animator.SetBool("isJumping", true);
                } else if (verticalVelocity < -0.1) {
                    animator.SetBool("isFalling", true);
                    animator.SetBool("isJumping", false);
                    isFalling = true;
                } else {
                    animator.SetBool("isFalling", false);
                    animator.SetBool("isJumping", false);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (waterJumpCooldownTimer > 0f)
            {
                waterJumpCooldownTimer -= Time.deltaTime; // Reduce the cooldown timer
            }

            // Check for input to establish or break a rope bind
            if (Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("G pressed");
                
                GameObject ropeManagerObj = GameObject.Find("RopeManager");
                if (ropeManagerObj != null)
                {
                    //RopeManager ropeManager = ropeManagerObj.GetComponent<RopeManager>();
                    //ropeManager.HandleBindInput(KeyCode.G);
                }
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("H pressed");
                //ropeManager.GetComponent<RopeManager>().HandleBindInput(KeyCode.H);
                GameObject ropeManagerObj = GameObject.Find("RopeManager");
                if (ropeManagerObj != null)
                {
                    //RopeManager ropeManager = ropeManagerObj.GetComponent<RopeManager>();
                    //ropeManager.HandleBindInput(KeyCode.H);
                }
            }
        }
    }

    private void Jump ()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void CollisionCheck(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);

        Collider2D[] colliders = new Collider2D[5]; // Adjust the array size as needed
        int count = Physics2D.OverlapCircleNonAlloc(groundCheck.position, groundCheckRadius, colliders, playerLayer);
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                PlayerScript otherPlayer = colliders[i].GetComponent<PlayerScript>();
                if (otherPlayer != null && otherPlayer != this)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            isSwimming = true;
            //animator.SetBool("isSwimming", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Water")
        {
            isSwimming = false;
            animator.SetBool("isSwimming", false);
            // Apply jump boost
            if(waterJumpCooldownTimer <= 0f){
                rb.velocity = new Vector2(rb.velocity.x * (moveSpeed / swimSpeed), jumpForce);
                isGrounded = false;
                animator.SetBool("isJumping", true);
            }
            waterJumpCooldownTimer = waterJumpCooldown; // Start the cooldown timer
        }
    }
}
