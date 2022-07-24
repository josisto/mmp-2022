using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D r2d2;
    [SerializeField] public float speed=10f;
    [SerializeField] private LayerMask platformLayerMask;
    float moveHorizontal = 0f;
    bool facesRight = true;
    bool isGrounded = false;
    const float extraHeight = .1f;
    // float moveVertical = 0f;

    public float jumpStrength=15f;
    public Animator playerAnimator;
    
    [SerializeField] private float smoothing = .05f;
    [SerializeField] private BoxCollider2D mushroomCollider;
    private BoxCollider2D boxCollider2d;
    private SpriteRenderer spriteRenderPlayer;
    private Vector3 velocity = Vector3.zero;

    // private AudioManager audioManager;
    public bool eating=false;

    //audiomanager
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        r2d2 = GetComponent<Rigidbody2D>(); 
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        spriteRenderPlayer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No AM File!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // reading input of the x value
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        // moveVertical = Input.GetAxisRaw("Vertical");
        //moveVertical = r2d2.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !eating)
        {
            playerAnimator.SetBool("Jump", true);
            Jump();
        } 

    }

    void FixedUpdate()
    {
        GroundCheck();
        if(!eating)
        {
            Move(moveHorizontal);
        }  
    }

    void GroundCheck()
    {
        // checks if the player collides with other 2D Colliders
        isGrounded = false;

        RaycastHit2D raycastHit;
        if(r2d2.gravityScale>0){
            raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size,0f,Vector2.down, extraHeight, platformLayerMask);
        } else{
            raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size,0f,Vector2.up, extraHeight, platformLayerMask);
        }

        if (raycastHit.collider != null) {
            isGrounded = true;
        }

        if (r2d2.gravityScale > 0)
        {
    	    if (r2d2.velocity.y < 0 && !isGrounded) 
            {
                playerAnimator.SetBool("Jump", isGrounded);
            }
        }
        else {
            if (r2d2.velocity.y > 0 && !isGrounded) 
            {   
                playerAnimator.SetBool("Jump", isGrounded);
            }
        }
        
    }

    void Move(float direction)
    {
        Vector3 movementVelocity = new Vector2(moveHorizontal * speed, r2d2.velocity.y);
        // Vector3 movementVelocity = new Vector2(moveHorizontal * speed * 90 * Time.fixedDeltaTime, r2d2.velocity.y);
        r2d2.velocity = Vector3.SmoothDamp(r2d2.velocity, movementVelocity, ref velocity, smoothing);

        // current scale value for character flip
        Vector3 currentScale = transform.localScale;

        // players' look direction check
        // facing right and clicking left - switch direction
        if (facesRight && direction < 0) {
            currentScale.x *= -1;
            facesRight = false;
        }
        // facing left and clicking right - switch direction
        else if (!facesRight && direction > 0) {
            currentScale.x *= -1;
            facesRight = true;
        }

        transform.localScale = currentScale;

        // current players horisontal and vertical values
        playerAnimator.SetFloat("HorizontalSpeed", Mathf.Abs(r2d2.velocity.x));
        playerAnimator.SetFloat("Vertical", (r2d2.velocity.y));

        audioManager.PlaySound("walk");
    }

    void Jump()
    {
        r2d2.velocity = Vector2.up * jumpStrength;
        audioManager.PlaySound("jump");
    }

    public void reset()
    {
        Vector3 currentScale = transform.localScale;

        if (r2d2.gravityScale > 0) {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (currentScale.x < 0)
                {
                    currentScale.x *= -1;
                    facesRight = true;
                }  
            } 
            else if (Input.GetAxisRaw("Horizontal") < 0) {
                if (currentScale.x > 0) 
                {
                    currentScale.x *= -1;
                    facesRight = false;
                } 
            }
        } else {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (currentScale.x < 0)
                {
                    currentScale.x *= -1;
                    facesRight = true;
                }  
            } 
            else if (Input.GetAxisRaw("Horizontal") < 0) {
                if (currentScale.x > 0) 
                {
                    currentScale.x *= -1;
                    facesRight = false;
                } 
            }
        }
        transform.localScale = currentScale;
    }
}
