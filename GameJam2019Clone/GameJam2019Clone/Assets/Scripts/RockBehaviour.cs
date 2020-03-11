using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour {
    private float speed = 15;
    public Vector3 targetPos;
    public GameObject shadow;
    GameObject newShadow;

    GameObject spawner;
    RockSpawner rockSpawner;

    public bool isSpawned = false;

    void Start() {
        if (!isSpawned) {
            spawner = GameObject.Find("RockSpawner");
            rockSpawner = spawner.GetComponent<RockSpawner>();
            targetPos = rockSpawner.randomPos;
            isSpawned = true;
        }

        newShadow = Instantiate(shadow, targetPos, Quaternion.identity);
        newShadow.transform.parent = gameObject.transform;
    }

    void FixedUpdate() {
        //keep resetting the shadow position to make sure it stands still
        newShadow.transform.position = targetPos;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        //destroy if it has reached its target
        if (Vector3.Distance(transform.position, targetPos) <= 0.1f) {
            Destroy(this.gameObject);
            Destroy(newShadow);
        }
    }
}
