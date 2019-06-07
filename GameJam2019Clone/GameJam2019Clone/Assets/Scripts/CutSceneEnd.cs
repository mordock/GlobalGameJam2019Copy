using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneEnd : MonoBehaviour
{
    private void OnEnable() {
        SceneManager.LoadScene("MainScene");   
    }
}
