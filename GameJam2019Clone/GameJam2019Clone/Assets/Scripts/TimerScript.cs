using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    private float currentTime = 90f;
    private float totalTime = 90f;
    public Text text;

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0) {
            currentTime = totalTime;
        }
        text.text = currentTime.ToString("0"); ;
    }
}
