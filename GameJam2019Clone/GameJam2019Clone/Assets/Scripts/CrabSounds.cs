using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSounds : MonoBehaviour
{
    FMOD.Studio.EventInstance crab;

    // Start is called before the first frame update
    void Start()
    {
        crab = FMODUnity.RuntimeManager.CreateInstance("event:/Crab");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(crab, transform, GetComponent<Rigidbody2D>());
        crab.start();
        crab.release();

    }

    private void OnDestroy()
    {
        crab.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

}
