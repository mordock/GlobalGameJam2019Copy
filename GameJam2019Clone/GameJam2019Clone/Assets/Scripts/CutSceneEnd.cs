using UnityEngine;

public class CutSceneEnd : MonoBehaviour
{
    public int levelToLoad;
    private void OnEnable() {
        LevelChanger.startFade = true;
        LevelChanger.levelToLoad = levelToLoad;
    }

    public void LoadOptions() {
        LevelChanger.startFade = true;
        LevelChanger.levelToLoad = 3;
    }
}
