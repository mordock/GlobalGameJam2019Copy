using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsManager : MonoBehaviour
{
    FMOD.Studio.EventInstance FootstepsInst;
    public GameObject Player;
    private PlayerBehaviour pb;

    bool playerismoving;

    public float walkingspeed;
    private float MaterialValue;

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gravel")
        {
            MaterialValue = 1;
        }
        else if (collision.gameObject.tag == "Water")
        {
            MaterialValue = 2;
        }
        else if (collision.gameObject.tag == "Boat")
        {
            MaterialValue = 3;
        }
        else
        {
            MaterialValue = 1;
        }
    }

    private void CallFootsteps()
    {

        if (playerismoving == true)
        {
            FootstepsInst.setParameterByName("Material", MaterialValue, false);
            FootstepsInst.start();
        }
    }

    private void Start()
    {
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
        pb = gameObject.GetComponent<PlayerBehaviour>();
        FootstepsInst = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps New");
    }

    private void Update()
    {
        if (pb.hasMediumPot == true)
            walkingspeed = 0.5f;
        else if (pb.hasLargePot == true)
            walkingspeed = 0.7f;
        else walkingspeed = 0.25f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            playerismoving = true;
        }
        else
        {
            playerismoving = false;
        }
    }
    private void OnDisable()
    {
        playerismoving = false;
    }
    private void OnDestroy()
    {
       FootstepsInst.release();
    }
}