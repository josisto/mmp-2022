using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float speed;
    private Rigidbody2D r2d2;
    [SerializeField] private float friction;
    [SerializeField] private float jumpStrength;
    private BoxCollider2D boxCollider2d;
    private SpriteRenderer spriteRenderPlayer;

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
        r2d2.constraints = RigidbodyConstraints2D.FreezePositionX;
        r2d2.constraints = RigidbodyConstraints2D.None;
        r2d2.constraints = RigidbodyConstraints2D.FreezeRotation;

        float moveHorizontal = Input.GetAxis("Horizontal");
        if(moveHorizontal<0){
            spriteRenderPlayer.flipX = true;
        } else{
            spriteRenderPlayer.flipX = false;
        }
        Vector3 movement = new Vector3(moveHorizontal,0,0);
        r2d2.AddForce(movement*speed);
        
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }

    void Jump()
    {
        Vector2 jump = new Vector2(0,jumpStrength);
        r2d2.AddForce(jump, ForceMode2D.Impulse);
        
    }

    private bool IsGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size,0f,Vector2.down, extraHeight, platformLayerMask);
        return raycastHit.collider != null;
    }
}
