using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    enum STATE
    {
        ACTIVATED,
        DEACTIVATED
    }

    public AudioSource musicSource;
    public AudioSource effectsSource;

    public List<Sprite> buttonSpriteEffects;

    public GameObject effectsButton;
    public GameObject musicButton;

    //public ObjectMovement chihuahuaRef;
    bool musicActivated = true;
    bool effectsActivated = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void deactivateMusic()
    {
        if (musicActivated)
        {
            //musicButton.s
            musicSource.volume = 0;
            musicActivated = false;
        }
        else
        {
            musicSource.volume = 1;
            musicActivated = true;
        }
    }

    public void DeactivateEffects()
    {
        if (effectsActivated)
        {
            effectsSource.volume = 0;
            effectsActivated = false;
        }
        else
        {
            effectsSource.volume = 1;
            effectsActivated = true;
        }
    }
}
