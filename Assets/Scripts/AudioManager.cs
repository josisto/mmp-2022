// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

// sound object
[System.Serializable]
public class Sound {
    public string name;     // the name of our music/effect
    public AudioClip clip;  // the actual music/effect
    
    
    [Range(0f, 1f)]         // limit the range in the Unity editor
    public float volume = 0.7f;    // volume

    [Range(0.5f, 1.5f)]       // limit the range in the Unity editor
    public float pitch = 1f;     // set the picth for our music/effect

    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;   // random volume value

    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;   // random volume value
    
    public bool loop = false; // should this sound loop
    
    // [HideInInspector]       //Hide this variable from the Editor
    // public bool isCollectionOfSounds = false;

    private AudioSource source; // the source that will play the sound

    public void SetSource (AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play() 
    {
        // variating the volume and pitch each time the sound plays
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{
<<<<<<< Updated upstream
    //public List<AudioClip>() sfxLibrary;
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }
=======
    public static AudioManager instance;
    
    [SerializeField]
    Sound[] sounds;
    // [SerializeField]
    // Sound[] soundRandomizedCollections;
    // SoundRandomController[] soundRandomizedCollections;
    // [SerializeField]
    // Sound[] trackLoops;
>>>>>>> Stashed changes

    void Awake()
    {
        if (instance != null)
        {
            if (instance != this) {
                // Debug.LogError("More than one Audio Manager in the scene.");
                Destroy(gameObject);
            return;
            }
        } else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        
<<<<<<< Updated upstream
    //}
=======
    }
    
    void Start()
    {
        // adding the sounds
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }

        // testing - it works!
        // PlaySound("walk");
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
    }
>>>>>>> Stashed changes
}
