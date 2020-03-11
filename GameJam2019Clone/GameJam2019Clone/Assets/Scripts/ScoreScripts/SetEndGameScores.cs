using UnityEngine;
using UnityEngine.UI;

public class SetEndGameScores : MonoBehaviour {
    private TimerScript timerScript;

    public Text endGameTextScore;
    public Text endGameTextHighScore;

    public GameObject endGameCanvas;
    public GameObject staticCanvas;

    private int scoreValue;
    private int highscoreValue;
    void Start() {
        timerScript = GetComponent<TimerScript>();
        endGameCanvas.SetActive(false);
        staticCanvas.SetActive(true);
    }

    void Update() {
        scoreValue = ScoreKeeper.score;
        highscoreValue = ScoreKeeper.hightScore;
        if (timerScript.currentTime <= 0) {
            endGameCanvas.SetActive(true);
            endGameTextScore.text = scoreValue.ToString();
            endGameTextHighScore.text = highscoreValue.ToString();
            staticCanvas.SetActive(false);
        }
    }
}
