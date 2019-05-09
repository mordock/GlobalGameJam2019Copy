using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public Text text;

    public static int score = 0;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        text.text = score.ToString();
    }

    public static void IncreaseScore(int points) {
        score += points;
    }

}
