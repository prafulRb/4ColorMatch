using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    public AudioClip eatSound;
    public AudioClip dieSound;
    AudioSource soundSource;
    // Use this for initialization
    void Start () {
        soundSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayEatSound()
    {
        soundSource.clip = eatSound;
        soundSource.Play();
    }

    public void PlayDieSound()
    {
        soundSource.clip = dieSound;
        soundSource.Play();
    }
}
