using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    [Header("Movement")]
    public float playerSpeed;
    float moveX;    
    Rigidbody2D rb;
    bool facingRight= true;
    Animator myAnimator;

    [Header("Jumping")]
    public bool jump;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [SerializeField]
    float jumpForce = 50;
    [SerializeField]
    bool isTouchingGround;
    [SerializeField]
    float groundRadius;
    [SerializeField]
    LayerMask whatIsGround;    
    [SerializeField]
    private Transform[] groundPoints;
    bool isGrounded;
    [Header("Audio")]
    public GameObject audio;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        
        
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();

        isGrounded = IsGrounded();

        
	}

    private void PlayerMove()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
        //ANIMATIONS
        myAnimator.SetFloat("xSpeed", Mathf.Abs(moveX));
        //SPRTIE FLIP
        if(moveX > 0 && facingRight == false)
        {
            FlipPlayer();
        }
        else if(moveX < 0 && facingRight == true)
        {
            FlipPlayer();
        }
        //PHYSICS
        rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);       
        //jumping
        if (isGrounded && jump)
        {
            //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            rb.velocity = Vector2.up * jumpForce;
            myAnimator.SetBool("Jumping", true);
            audio.GetComponent<Sounds>().PlaySound(1,false);
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
        if(Mathf.Abs(rb.velocity.y) <= 0.1)
        {
            myAnimator.SetBool("Jumping", false);
        }

    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        gameObject.transform.localScale = localScale;
    }

    private bool IsGrounded()
    {
        foreach(Transform point in groundPoints)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
            for(int i = 0; i < colliders.Length; i++)
            {
                if(colliders[i].gameObject != gameObject)
                {
                    return true;
                    
                }
            }
        }
        return false;
    }
}
