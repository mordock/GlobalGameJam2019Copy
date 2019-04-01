using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {
    public float totalTime;
    private float rockTimer;

    public GameObject[] rock;

    public Vector3 center, size;
    public Vector3 randomPos;

    // Use this for initialization
    void Start() {
        rockTimer = totalTime;
    }

    // Update is called once per frame
    void Update() {
        rockTimer -= Time.deltaTime;
        if (rockTimer <= 0) {
            SpawnRock();
            rockTimer = totalTime;
        }
    }

    void SpawnRock() {
        randomPos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), -2f);

        int randomRock = Random.Range(0, 3);

        GameObject newRock = Instantiate(rock[randomRock], new Vector3(randomPos.x, randomPos.y + 50, randomPos.z), Quaternion.identity);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(center, size);
    }
}
