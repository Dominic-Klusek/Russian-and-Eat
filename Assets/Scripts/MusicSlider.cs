using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour {
    private Slider musicSlider;
    private Button musicButton;
    private Animator sliderAnimator;
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
		
	}

    void changeMusicVolume()
    {
        SoundManager.getInstance().setMusicVolume(musicSlider.value);
    }

    private void toggleSlider()
    {
        // toggle isHidden bool
        sliderAnimator.SetBool("isHidden", !sliderAnimator.GetBool("isHidden"));
    }
}
