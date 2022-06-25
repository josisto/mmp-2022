using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    [SerializeField] private Rigidbody2D r2d2Player;
    [SerializeField] private BoxCollider2D Player;
    [SerializeField] private SpriteRenderer PlayerSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other){
        if (other == Player){
            yield return new WaitForSeconds(1);
            r2d2Player.gravityScale *= -1;
            yield return new WaitForSeconds(1);
            PlayerSprite.flipY=true;
        }
        
    }
}
