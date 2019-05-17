﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    private float currentTime = 90f;
    public float totalTime = 90f;
    public Text text;

    public GameObject endGameCanvas;
    public GameObject staticCanvas;

    private void Start() {
        currentTime = totalTime;
        endGameCanvas.SetActive(false);
        staticCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            Time.timeScale = 0;
            endGameCanvas.SetActive(true);
            staticCanvas.SetActive(false);
        }
        text.text = currentTime.ToString("0"); ;
    }
}
