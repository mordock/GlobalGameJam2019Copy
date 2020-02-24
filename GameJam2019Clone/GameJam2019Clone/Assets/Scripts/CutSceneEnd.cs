using UnityEngine;

public class CutSceneEnd : MonoBehaviour
{
    private void OnEnable() {
        LevelChanger.startFade = true;
        LevelChanger.levelToLoad = 2;
    }

    public void LoadOptions() {
        LevelChanger.startFade = true;
        LevelChanger.levelToLoad = 3;
    }
}
