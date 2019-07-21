using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public static bool startFade = false;

    private int levelToLoad;

    private void Start() {
        startFade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startFade) {
            FadeToLevel(2);
        }
    }

    public void CinematicEnd() {
        startFade = true;
    }

    public void FadeToLevel(int levelIndex) {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fade Out");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}
