using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimizer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other){
        Rigidbody2D playerr2d2 = Player.GetComponent<Rigidbody2D>();
        BoxCollider2D playerBox =  Player.GetComponent<BoxCollider2D>();
        SpriteRenderer playerSprite = Player.GetComponent<SpriteRenderer>();
        Transform playerTransform = Player.GetComponent<Transform>();

        if (other == playerBox){
            yield return new WaitForSeconds(1);
            playerBox.size.Scale(new Vector2(0.1f,0.1f));
            playerTransform.localScale = new Vector3(2.0f,2.01f,2.0f);
        }  
    }
}
