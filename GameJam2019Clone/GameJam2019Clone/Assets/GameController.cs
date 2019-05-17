using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject endGameCanvas;
    public GameObject staticCanvas;

    void Start() {
        endGameCanvas.SetActive(false);
        staticCanvas.SetActive(true);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update() {

    }
}
