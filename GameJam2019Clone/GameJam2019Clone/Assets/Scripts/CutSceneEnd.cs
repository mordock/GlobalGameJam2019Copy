using UnityEngine;

public class CutSceneEnd : MonoBehaviour
{
    private void OnEnable() {
        LevelChanger.startFade = true;
    }
}
