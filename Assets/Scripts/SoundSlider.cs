using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour {
    private Slider soundSlider;

	// Use this for initialization
	void Start () {
        soundSlider = GetComponentInChildren<Slider>();
        soundSlider.onValueChanged.AddListener(delegate { changeSoundVolume(); });
    }

    // Update is called once per frame
    void Update () {
	}

    void changeSoundVolume()
    {
        SoundManager.getInstance().setSoundVolume(soundSlider.value);
    }

}
