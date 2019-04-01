using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPots : MonoBehaviour {

    public GameObject smallPot, mediumPot, LargePot;
    GameObject clone;

    bool smallPotExists, MediumPotExists, LargePotExists;

    public static bool spawnSmallPot = true, spawnMediumPot = true, spawnLargePot = true;

    public static float smallTime = 3f, mediumTime = 3f, largeTime = 3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        smallTime -= Time.deltaTime;
        mediumTime -= Time.deltaTime;
        largeTime -= Time.deltaTime;

        if (spawnSmallPot) {
            if(smallTime <= 0){
                clone = (GameObject) Instantiate(smallPot, new Vector3(19f,  -1.3f, -2f), Quaternion.identity);
                clone.name = smallPot.name;
                spawnSmallPot = false;
                //smallTime = rechargeTime;
            }
        }

        if (spawnMediumPot) {
            if (mediumTime <= 0f) {
                clone = (GameObject)Instantiate(mediumPot, new Vector3(19f, -5f, -2f), Quaternion.identity);
                clone.name = mediumPot.name;
                spawnMediumPot = false;
                //mediumTime = rechargeTime;
            }
        }

        if (spawnLargePot) {
            if(largeTime <= 0f) {
                clone = (GameObject)Instantiate(LargePot, new Vector3(19f, -10f, -2f), Quaternion.identity);
                clone.name = LargePot.name;
                spawnLargePot = false;
                //largeTime = rechargeTime;
            }
        }
	}
}
