using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWaterSounds : MonoBehaviour
{
    FMOD.Studio.EventInstance Water;

    // Start is called before the first frame update
    void Start()
    {
        Water = FMODUnity.RuntimeManager.CreateInstance("event:/End Water");
        Water.start();
        Water.release();
        
    }

    private void OnDestroy()
    {
        Water.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
