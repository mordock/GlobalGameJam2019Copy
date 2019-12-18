using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public Text Scoretext;
    public Text hightScoreText;

    public static int score = 0;
    public static int hightScore;

    void Start() {
        score = 0;
        hightScore = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update() {
        Scoretext.text = score.ToString();
        hightScoreText.text = hightScore.ToString();
    }

    public static void IncreaseScore(int points) {
        score += points;
    }
}
