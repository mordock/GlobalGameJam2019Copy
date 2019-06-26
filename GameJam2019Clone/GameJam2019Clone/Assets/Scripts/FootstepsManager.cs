using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputsound;
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

        void CallFootsteps ()
    {
        if (playerismoving == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot (inputsound);
        }
    }

    private void Start()
    {
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }
    private void OnDisable()
    {
        playerismoving = false;
    }
}