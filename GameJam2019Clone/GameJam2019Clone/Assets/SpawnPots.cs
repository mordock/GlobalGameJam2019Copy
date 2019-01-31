using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPots : MonoBehaviour {

    public GameObject smallPot, mediumPot, LargePot;

    bool smallPotExists, MediumPotExists, LargePotExists;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!smallPotExists) {
            Instantiate(smallPot, new Vector3(-1.3f, 0.65f, -1f), Quaternion.identity);
            smallPotExists = true;
        }
	}
}
