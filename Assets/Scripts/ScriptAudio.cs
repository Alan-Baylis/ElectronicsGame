using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptAudio : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public Slider Slider;

    private int cpt = 0;

	// Use this for initialization
	void Start () {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        MusicSource.volume = Slider.value;
	}

    public void PlayStopMusic()
    {
        if(cpt == 0)
        {
            MusicSource.Stop();

            cpt++;
        } else
        {
            MusicSource.Play();
            cpt--;
        }
    }
}
