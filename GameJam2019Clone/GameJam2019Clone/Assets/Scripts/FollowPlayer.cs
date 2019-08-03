using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject player;
    public GameObject ground;

    public Renderer groundRenderer;

    private Vector2 rightBound, leftBound;

    void LateUpdate() {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
