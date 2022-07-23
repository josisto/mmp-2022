using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerrigid;
    
    private Func<Vector3> GetCameraFollowPosition;
    private Vector3 cameraShift;
    private bool coroutineRunning=false;

    public void Setup(Func<Vector3> GetCameraFollowPosition){
        this.GetCameraFollowPosition = GetCameraFollowPosition;
        this.cameraShift = new Vector3(0,10,0);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 cameraFollowPosition = GetCameraFollowPosition();
        cameraFollowPosition.z = transform.position.z;

        if(!coroutineRunning)
        {
            StartCoroutine(shift());
        }
        
        transform.position = cameraFollowPosition+cameraShift;
    }

    IEnumerator shift()
    {
        coroutineRunning = true;
        yield return new WaitForSeconds(1);
        this.cameraShift= new Vector3(0,playerrigid.gravityScale*2,0);  
        coroutineRunning = false;
    }
}
