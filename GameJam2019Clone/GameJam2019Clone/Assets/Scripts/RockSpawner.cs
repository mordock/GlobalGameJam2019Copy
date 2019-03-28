using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {

    public GameObject[] rock;

    public GameObject range;

    public Vector3 center;
    public Vector3 size;

    public float speed = 8;

    public Vector3 randomPos;

	// Use this for initialization
	void Start () {
         
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            SpawnRock();
        }
	}

    void SpawnRock() {
        randomPos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), -2f);

        int randomRock = Random.Range(0, 2);

        GameObject newRock = Instantiate(rock[randomRock], new Vector3(randomPos.x, randomPos.y + 50, randomPos.z), Quaternion.identity);

        //newRock.transform.position = Vector3.MoveTowards(transform.position, randomPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(center, size);
    }
}
