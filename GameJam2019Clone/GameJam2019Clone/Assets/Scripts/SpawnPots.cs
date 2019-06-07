using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPots : MonoBehaviour {

    public GameObject smallPot, mediumPot, LargePot;
    GameObject clone;

    bool smallPotExists, MediumPotExists, LargePotExists;

    public static bool spawnSmallPot = true, spawnMediumPot = true, spawnLargePot = true;
    public static float smallTime, mediumTime, largeTime;

    public float smallSpawnTime = 5f, mediumSpawnTime = 5f, largeSpawnTime = 5f;

    // Use this for initialization
    void Start ()
    {
        //set values at the beginning of the game in case of a restart
        smallTime = smallSpawnTime;
        mediumTime = mediumSpawnTime;
        largeTime = largeSpawnTime;
        spawnSmallPot = true;
        spawnMediumPot = true;
        spawnLargePot = true;
    }
	
	void Update () {
        smallTime -= Time.deltaTime;
        mediumTime -= Time.deltaTime;
        largeTime -= Time.deltaTime;

        if (spawnSmallPot) {
            if(smallTime <= 0){
                clone = (GameObject) Instantiate(smallPot, new Vector3(19f,  -0.3f, -2f), Quaternion.identity);
                clone.name = smallPot.name;
                spawnSmallPot = false;
            }
        }

        if (spawnMediumPot) {
            if (mediumTime <= 0f) {
                clone = (GameObject)Instantiate(mediumPot, new Vector3(19f, -5f, -2f), Quaternion.identity);
                clone.name = mediumPot.name;
                spawnMediumPot = false;
            }
        }

        if (spawnLargePot) {
            if(largeTime <= 0f) {
                clone = (GameObject)Instantiate(LargePot, new Vector3(19f, -11f, -2f), Quaternion.identity);
                clone.name = LargePot.name;
                spawnLargePot = false;
            }
        }
	}
}
