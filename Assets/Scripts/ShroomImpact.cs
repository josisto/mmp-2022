using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomImpact : MonoBehaviour
{
    [SerializeField] private int size; // 0 is smal, 1 is normal
    [SerializeField] private int weight; // 0 is light, 1 is normal, 2 is heavy
    [SerializeField] public string shroomType;
    [SerializeField] public bool canEatShroom;
    private Rigidbody2D r2d2;
    private BoxCollider2D boxCollider2d;
    private SpriteRenderer playerSprite;
    private Transform playerTransform;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Collider2D tilemapCollider;

    // Start is called before the first frame update
    void Start()
    {
        size=1;
        weight = 1;
        shroomType="";
        canEatShroom=false;
        r2d2 = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit") && canEatShroom){ 
            eatShroom(shroomType);
        }
    }

    void eatShroom(string shroomType){
        //update shroomScore
        ScoreManager.instance.AddShroom();

        if(string.Equals(shroomType,"gravity")){ 
            r2d2.gravityScale *= -1;
            playerMovement.jumpStrength *= -1;
            if(r2d2.gravityScale<0){
                playerSprite.flipY=true;
            }else{
                playerSprite.flipY=false;
            }
        }
        if(string.Equals(shroomType,"resize")){ 
            float scaler =0;
            if(size==0){
                scaler = 2.0f;
                size =1;
            }else if(size>0){
                scaler = 0.5f;
                size=0;
            }
            boxCollider2d.size.Scale(scaler*new Vector2(1.0f,1.0f));

            playerTransform.localScale = playerTransform.localScale*scaler;
        }

        if(string.Equals(shroomType,"light")){ 
            r2d2.mass = 0.5f;
            playerMovement.jumpStrength *=1.5f;
        }

        if(string.Equals(shroomType,"heavy")){ 
            r2d2.mass = 2;
            playerMovement.jumpStrength *=0.7f;
        }

        if(string.Equals(shroomType,"ghost")){ 
            tilemapCollider.enabled=!tilemapCollider.enabled;
        }
    }
}
