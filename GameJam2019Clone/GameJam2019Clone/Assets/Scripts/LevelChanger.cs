using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public static bool startFade = false;
    public static int levelToLoad;

    //private int levelToLoad;

    private void Start() {
        startFade = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
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
