using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyIndicator : MonoBehaviour {
    private Text buttonText;
    private int playerMoney;

    // Use this for initialization
    void Start () {
        buttonText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void updatePlayerMoneyDisplayed()
    {
        buttonText.text = GameManager.getInstance().getPlayerMoney().ToString();
    }

}
