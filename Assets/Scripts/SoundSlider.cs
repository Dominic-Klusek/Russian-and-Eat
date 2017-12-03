using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour {
    private Slider soundSlider;
    private Button soundButton;
    private Animator sliderAnimator;

    // Use this for initialization
    void Start () {
        soundSlider = GetComponentInChildren<Slider>();
        soundSlider.value = SoundManager.getInstance().getSoundVolume();
        soundSlider.onValueChanged.AddListener(delegate { changeSoundVolume(); });

        soundButton = soundSlider.GetComponentInParent<Button>();
        soundButton.onClick.AddListener(delegate { toggleSlider(); });

        sliderAnimator = soundSlider.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
	}

    void changeSoundVolume()
    {
        SoundManager.getInstance().setSoundVolume(soundSlider.value);
    }

    private void toggleSlider()
    {
        sliderAnimator.SetBool("isHidden", !sliderAnimator.GetBool("isHidden"));
    }
}
