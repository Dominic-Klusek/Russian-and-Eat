using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour {
    public float secondsUntilHidingIdleSlider = 3;

    private Slider musicSlider;
    private Button musicButton;
    private Animator sliderAnimator;
    private bool isSliderHidden;
    private float secondsSliderIdle = 0;
    
    // Use this for initialization
    void Start () {
        musicSlider = GetComponentInChildren<Slider>();
        musicSlider.value = SoundManager.getInstance().getMusicVolume();
        musicSlider.onValueChanged.AddListener(delegate { changeMusicVolume(); });

        musicButton = musicSlider.GetComponentInParent<Button>();
        musicButton.onClick.AddListener(delegate { toggleSlider(); });

        sliderAnimator = musicSlider.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (!isSliderHidden)
        {
            secondsSliderIdle += Time.deltaTime;
            if (secondsSliderIdle >= secondsUntilHidingIdleSlider)
            {
                toggleSlider();
                secondsSliderIdle = 0;
            }
        }
    }

    void changeMusicVolume()
    {
        SoundManager.getInstance().setMusicVolume(musicSlider.value);
        secondsSliderIdle = 0;
    }

    private void toggleSlider()
    {
        isSliderHidden = !isSliderHidden;
        sliderAnimator.SetBool("isHidden", isSliderHidden);
    }
}
