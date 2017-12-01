using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {
    public int secondsPerRound = 60;
    public bool timerActive = true;

    private int currentTime = 0;
    private int timeIncrement = 0;
    private Slider timer;
    private Image timerFill;

	// Use this for initialization
	void Start () {
        //timer = FindObjectOfType<Slider>();
        timer = GameObject.Find("Time Bar").GetComponent<Slider>();
        //timerFill = timer.GetComponentInChildren<Image>();
        timerFill = timer.transform.Find("Fill Area").GetComponentInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timerActive)
        {
            timer.value += Time.deltaTime / secondsPerRound;
            timerFill.color = Color.Lerp(Color.green, Color.red, timer.value);
            if (timer.value >= 1)
                GameManager.getInstance().LoadNextScene();
        }
    }
}
