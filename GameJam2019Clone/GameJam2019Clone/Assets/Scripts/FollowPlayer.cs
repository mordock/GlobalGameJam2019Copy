using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject player;
    public GameObject ground;

    public Renderer groundRenderer;

    private Vector2 screenBounds;
    private Vector2 rightBound, leftBound;

    void Start() {
        //make sure camera doesn't go below the playing field
        screenBounds =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void LateUpdate() {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
