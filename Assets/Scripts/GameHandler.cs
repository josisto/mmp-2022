using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public FollowPlayer followPlayer;
    public Transform playerTransform;

    // cache
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    { 
        followPlayer.Setup(() => playerTransform.position);

        // caching
        audioManager = AudioManager.instance;

        if (audioManager == null) {
            Debug.LogError("ALERT! No AudioManager in the scene!");
        }

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
