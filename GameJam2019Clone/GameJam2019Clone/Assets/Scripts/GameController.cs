using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject endGameCanvas;
    public GameObject staticCanvas;

    void Start() {
        endGameCanvas.SetActive(false);
        staticCanvas.SetActive(true);
        Time.timeScale = 1;
    }
}
