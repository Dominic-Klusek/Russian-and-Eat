using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource soundSource;
    public AudioSource musicSource;

    // represents the range of pitch sounds can make.
    // this adds a bit of variation to sounds.
    // making this value too high might result in off-sounding effects.
    [Range(.0f,.1f)]
    public float soundPitchRangePercentage = .05f;

    private float soundHighPitchRange = 1f;
    private float soundLowPitchRange = 1f;

    private static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        soundHighPitchRange += soundPitchRangePercentage;
        soundLowPitchRange -= soundPitchRangePercentage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        instance = null;
    }

    public void playAudioClip(AudioClip clip)
    {
        soundSource.clip = clip;
        soundSource.Play();

    }

    public void playAudioClipWithRandomizedPitch(AudioClip clip)
    {
        soundSource.clip = clip;
        soundSource.pitch = Random.Range(soundLowPitchRange, soundHighPitchRange);
        soundSource.Play();

    }

    public void setSoundVolume(float volume)
    {
        soundSource.volume = volume;
    }

    public void setMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public static SoundManager getInstance()
    {
        return instance;
    }
}
