using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartNewDay : MonoBehaviour {
    public void startNewDay()
    {
        GameManager.getInstance().LoadLevel1();
    }
}
