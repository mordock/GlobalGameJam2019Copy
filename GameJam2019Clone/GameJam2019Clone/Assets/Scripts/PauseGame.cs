using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
    public bool isPaused = false;

    public GameObject canvas;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    public void Pause() {
        if (isPaused) {
            Time.timeScale = 1;
            isPaused = false;
            canvas.SetActive(false);
        } else {
            Time.timeScale = 0;
            isPaused = true;
            canvas.SetActive(true);
        }
    }
}
