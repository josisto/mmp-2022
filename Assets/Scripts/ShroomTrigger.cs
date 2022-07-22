using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomTrigger : MonoBehaviour
{
    [SerializeField] private string ShroomType;
    [SerializeField] private ShroomImpact shroomImpact;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            shroomImpact.canEatShroom =true;
            shroomImpact.shroomType =ShroomType;
            ScoreManager.instance.enableText();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player"){
            shroomImpact.canEatShroom=false;
            ScoreManager.instance.disableText();
        }
    }
}
