using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour {
    private Slider musicSlider;

    // Use this for initialization
    void Start () {
        musicSlider = GetComponentInChildren<Slider>();
        musicSlider.onValueChanged.AddListener(delegate { changeMusicVolume(); });
    }

    // Update is called once per frame
    void Update () {
		
	}

    void changeMusicVolume()
    {
        SoundManager.getInstance().setMusicVolume(musicSlider.value);
    }
}
