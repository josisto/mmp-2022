using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public FollowPlayer followPlayer;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    { 
        followPlayer.Setup(() => playerTransform.position);
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
