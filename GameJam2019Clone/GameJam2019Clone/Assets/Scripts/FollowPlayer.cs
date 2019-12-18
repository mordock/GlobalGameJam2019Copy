using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject player;

    void LateUpdate() {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
