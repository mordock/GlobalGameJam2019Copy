using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
    public bool isPaused = false;

    public GameObject pauseCanvas;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    public void Pause() {
        if (isPaused) {
            Time.timeScale = 1;
            isPaused = false;
            pauseCanvas.SetActive(false);
            MusicPlayer.music.setPaused(false);
        } else {
            Time.timeScale = 0;
            isPaused = true;
            pauseCanvas.SetActive(true);
            MusicPlayer.music.setPaused(true);

        }
    }
}
