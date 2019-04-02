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

    // Start is called before the first frame update
    void Start() {
        if (!isSpawned) {
            spawner = GameObject.Find("RockSpawner");
            rockSpawner = spawner.GetComponent<RockSpawner>();
            targetPos = rockSpawner.randomPos;
            isSpawned = true;
        }

        newShadow = Instantiate(shadow, targetPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPos) <= 0.1f) {
            Destroy(this.gameObject);
            Destroy(newShadow);
        }
    }
}
