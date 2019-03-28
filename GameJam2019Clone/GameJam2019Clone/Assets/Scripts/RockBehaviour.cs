using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    public float speed;

    RockSpawner rockSpawner = new RockSpawner();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, rockSpawner.randomPos, speed * Time.deltaTime);
    }
}
