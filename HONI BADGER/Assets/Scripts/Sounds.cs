using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sounds : MonoBehaviour {

    public AudioClip[] sounds;
    AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

	public void PlaySound(int soundNumber, bool loop)
    {
        audio.clip = sounds[soundNumber];
        audio.Play();
        if (loop)
        {
            audio.loop = false;
        }
    }
}
