using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsManager : MonoBehaviour
{
    FMOD.Studio.EventInstance FootstepsInst;

    //whichever surface the player is on gets set to true
    public bool gravel;
    public bool wood;
    public bool water;

    bool playerismoving;
    public float walkingspeed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            playerismoving = true;
        }
        else
        {
            playerismoving = false;
        }
    }
    //sets correct surface boolean to true based on surface
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gravel")
        {
            gravel = true;
            wood = false;
            water = false;

        }
        else if (collision.gameObject.tag == "Boat")
        {
            gravel = false;
            wood = true;
            water = false;
        }
        else if (collision.gameObject.tag == "Water")
        {
            gravel = false;
            wood = false;
            water = true;
        }
        else
        {
            gravel = true;
            wood = false;
            water = false;
        }

    }


    //sets the FMOD parameter to the correct surface
    void UpdateSurface()
    {
        if (gravel == true)
        {
            FootstepsInst.setParameterByName("Gravel", 1f, false);
            FootstepsInst.setParameterByName("Wood", 0f, false);
            FootstepsInst.setParameterByName("Water", 0f, false);
        }
        else if (wood == true)

        {
            FootstepsInst.setParameterByName("Gravel", 0f, false);
            FootstepsInst.setParameterByName("Wood", 1f, false);
            FootstepsInst.setParameterByName("Water", 0f, false);
        }
        else if (water == true)

        {
            FootstepsInst.setParameterByName("Gravel", 0f, false);
            FootstepsInst.setParameterByName("Wood", 0f, false);
            FootstepsInst.setParameterByName("Water", 1f, false);
        }
    }

    //updates the surface, then plays a footstep event if the player is moving
    void CallFootsteps ()
    {

        if (playerismoving == true)
        {
            UpdateSurface();
            FootstepsInst.start();

        }
    }

    //sets the footstep FMOD event path and 
    private void Start()
    {
        gravel = true;
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
        FootstepsInst = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
    }
    private void OnDisable()
    {
        playerismoving = false;
    }
}