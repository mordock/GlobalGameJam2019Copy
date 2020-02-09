using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFObject : MonoBehaviour {
    public GameObject fPrefab;

    private GameObject fObject;

    private PlayerBehaviour playerBehaviour;

    private bool isFobject;

    void Start() {
        playerBehaviour = GetComponent<PlayerBehaviour>();
    }

    //make sure the F stays the correct way
    void FixedUpdate() {
        if (isFobject) {
            if (playerBehaviour.facingRight) {
                fObject.transform.localScale = new Vector3(-1, 1, 1);
            } else {
                fObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    //check if on a pot
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("SmallPot") || collider.CompareTag("MediumPot") || collider.CompareTag("LargePot") || collider.CompareTag("Boat")) {
            fObject = Instantiate(fPrefab,
                new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 5),
                Quaternion.identity, transform);
            isFobject = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        isFobject = false;
        Destroy(fObject);
    }
}
