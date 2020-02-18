using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneAudioPlayer : MonoBehaviour

{
    FMOD.Studio.Bus MasterBus;

    // Start is called before the first frame update
    void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
