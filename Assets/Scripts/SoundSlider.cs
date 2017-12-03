using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour {
    public float secondsUntilHidingIdleSlider = 3;

    private Slider soundSlider;
    private Button soundButton;
    private Animator sliderAnimator;
    private bool isSliderHidden;
    private float secondsSliderIdle = 0;

    // Use this for initialization
    void Start () {
        soundSlider = GetComponentInChildren<Slider>();
        soundSlider.value = SoundManager.getInstance().getSoundVolume();
        soundSlider.onValueChanged.AddListener(delegate { changeSoundVolume(); });

        soundButton = soundSlider.GetComponentInParent<Button>();
        soundButton.onClick.AddListener(delegate { toggleSlider(); });

        sliderAnimator = soundSlider.GetComponent<Animator>();
        isSliderHidden = sliderAnimator.GetBool("isHidden");
    }

    // Update is called once per frame
    void Update () {
        if (!isSliderHidden) {
            secondsSliderIdle += Time.deltaTime;
            if (secondsSliderIdle >= secondsUntilHidingIdleSlider)
            {
                toggleSlider();
                secondsSliderIdle = 0;
            }
        }
	}

    void changeSoundVolume()
    {
        SoundManager.getInstance().setSoundVolume(soundSlider.value);
        secondsSliderIdle = 0;
    }

    private void toggleSlider()
    {
        isSliderHidden = !isSliderHidden;
        sliderAnimator.SetBool("isHidden", isSliderHidden);
    }
}
