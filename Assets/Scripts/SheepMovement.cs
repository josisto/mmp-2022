using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3[] positions;
    private int index;

    private float delay;

    void Start()
    {
        index = 0;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
        
        if(transform.position == positions[index])
        {
            if(index>=positions.Length-1)
            {
                index=0;
            }
            else
            {
                index++;
            }
        }
    
    }

    // void FixedUpdate()
    // {
    //     delay = Random.Range(0.5f, 3f);
    //     PlaySheepSound();
    // }

    // public void PlaySheepSound()
    // {
    //     audioSource.clip = sheepSound;
    //     audioSource.PlayDelayed(delay);
    //     SoundRandomController.Trigger(sheepSoundController);
    // }

}