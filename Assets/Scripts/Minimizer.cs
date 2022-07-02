using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimizer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private bool isSmal;
    
    // Start is called before the first frame update
    void Start()
    {
        isSmal = false;
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
            float scaler;
            if(isSmal){
                scaler = 2.0f;
                isSmal=false;
            }else{
                scaler = 0.5f;
                isSmal=true;
            }
            yield return new WaitForSeconds(1);
            playerBox.size.Scale(scaler*new Vector2(1.0f,1.0f));

            playerTransform.localScale = playerTransform.localScale*scaler;
        }
    }
}
