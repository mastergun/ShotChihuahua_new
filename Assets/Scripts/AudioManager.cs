using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            musicButton.GetComponent<Button>().image.sprite = buttonSpriteEffects[(int)STATE.DEACTIVATED];
            musicActivated = false;
        }
        else
        {
            musicSource.volume = 1;
            musicButton.GetComponent<Button>().image.sprite = buttonSpriteEffects[(int)STATE.ACTIVATED];
            musicActivated = true;
        }
    }

    public void DeactivateEffects()
    {
        if (effectsActivated)
        {
            effectsSource.volume = 0;
            effectsButton.GetComponent<Button>().image.sprite = buttonSpriteEffects[(int)STATE.DEACTIVATED];
            effectsActivated = false;
        }
        else
        {
            effectsSource.volume = 1;
            effectsButton.GetComponent<Button>().image.sprite = buttonSpriteEffects[(int)STATE.ACTIVATED];
            effectsActivated = true;
        }
    }
}
