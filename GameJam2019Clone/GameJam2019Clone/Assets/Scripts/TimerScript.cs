using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    private float currentTime = 90f;
    public float totalTime = 90f;
    public Text text;
    public Text endGameText;

    public GameObject endGameCanvas;
    public GameObject staticCanvas;

    private int scoreValue;
    private int highscoreValue;

    private void Start() {
        currentTime = totalTime;
        endGameCanvas.SetActive(false);
        staticCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;
        scoreValue = ScoreKeeper.score;
        highscoreValue = ScoreKeeper.hightScore;
        if (currentTime <= 0) {
            Time.timeScale = 0;
            endGameCanvas.SetActive(true);
            staticCanvas.SetActive(false);
            SetEndGameScore();
            CheckHighScore();
        }
        text.text = currentTime.ToString("0"); ;
    }

    public void SetEndGameScore() {
        endGameText.text = scoreValue.ToString();
    }

    public void CheckHighScore() {
        if (scoreValue >= highscoreValue) {
            Debug.Log("BOB");
            PlayerPrefs.SetInt("Highscore", scoreValue);
            PlayerPrefs.Save();
        }
    }
}
