using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanSounds : MonoBehaviour
{
    FMOD.Studio.EventInstance Ocean;

    // Start is called before the first frame update
    void Start()
    {
        Ocean = FMODUnity.RuntimeManager.CreateInstance("event:/Ocean");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Ocean, transform, GetComponent<Rigidbody2D>());
        Ocean.start();
        Ocean.release();
    }

    private void OnDestroy()
    {
        Ocean.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}