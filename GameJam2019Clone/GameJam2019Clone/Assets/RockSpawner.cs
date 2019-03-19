using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {

    public GameObject[] rock;

    public Sprite background;

    public float minX, maxX, minY, maxY;

	// Use this for initialization
	void Start () {
        minY = background.border.y;
        maxY = background.border.w;
        minX = background.border.x;
        maxX = background.border.z - 20;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
