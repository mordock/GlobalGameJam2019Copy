using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject player;
    public GameObject ground;

    public Renderer groundRenderer;

    private Vector2 screenBounds;
    private Vector2 rightBound, leftBound;

    // Use this for initialization
    void Start() {
        screenBounds =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate() {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
