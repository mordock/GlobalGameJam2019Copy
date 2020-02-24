using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiancePlayer : MonoBehaviour
{
    FMOD.Studio.EventInstance ambiance;

    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Volcano gameplay");
        ambiance = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay Ambiance");
        ambiance.start();
        ambiance.release();
        
    }

    // Update is called once per frame
    void OnDestroy ()
    {
        ambiance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
