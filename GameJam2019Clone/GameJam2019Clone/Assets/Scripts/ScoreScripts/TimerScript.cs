using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    public float currentTime = 90f;
    public float totalTime = 90f;
    private Text timerText;

    private int scoreValue;
    private int highscoreValue;

    private void Start()
    {
        timerText = gameObject.GetComponent<Text>();

        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;
        scoreValue = ScoreKeeper.score;
        highscoreValue = ScoreKeeper.hightScore;
        if (currentTime <= 0) {
            Time.timeScale = 0;
            CheckHighScore();
        }
        timerText.text = currentTime.ToString("0"); ;
    }

    public void CheckHighScore() {
        if (scoreValue >= highscoreValue) {
            PlayerPrefs.SetInt("Highscore", scoreValue);
            PlayerPrefs.Save();
        }
    }
}
