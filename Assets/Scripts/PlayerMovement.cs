using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] public float speed=10f;
    private Rigidbody2D r2d2;
    float moveHorizontal = 0f;
    public float jumpStrength=15f;
    private BoxCollider2D boxCollider2d;
    private SpriteRenderer spriteRenderPlayer;
    [SerializeField] private float smoothing = .05f;
    private Vector3 velocity = Vector3.zero;

    public Animator playerAnimator;

    [SerializeField] private BoxCollider2D mushroomCollider;

    // Start is called before the first frame update
    void Start()
    {
        r2d2 = GetComponent<Rigidbody2D>(); 
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        spriteRenderPlayer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        moveHorizontal = Input.GetAxis("Horizontal");

        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }

    void FixedUpdate()
    {
        Vector3 movementVelocity = new Vector2(moveHorizontal * speed, r2d2.velocity.y);
        //r2d2.velocity = new Vector2(moveHorizontal*speed,r2d2.velocity.y);
        r2d2.velocity = Vector3.SmoothDamp(r2d2.velocity, movementVelocity, ref velocity, smoothing);
    }

    void Jump()
    {     
        //r2d2.velocity = new Vector2(r2d2.velocity.x, jumpStrength);
        r2d2.velocity = Vector2.up * jumpStrength;    
    }

    private bool IsGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit;
        if(r2d2.gravityScale>0){
            raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size,0f,Vector2.down, extraHeight, platformLayerMask);
        } else{
            raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size,0f,Vector2.up, extraHeight, platformLayerMask);
        }
        return raycastHit.collider != null;
    }
}
