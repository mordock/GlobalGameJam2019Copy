using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public static bool startFade = false;
    public static int levelToLoad;
    private void Start() {
        startFade = false;
        Time.timeScale = 1;
    }

    void Update() {
        if (startFade) {
            FadeToLevel();
        }
    }

    public void CinematicEnd() {
        startFade = true;
    }

    public void FadeToLevel() {
        animator.SetTrigger("Fade Out");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}
