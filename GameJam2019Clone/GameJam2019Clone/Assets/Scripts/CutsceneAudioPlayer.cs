using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneAudioPlayer : MonoBehaviour

{
    FMOD.Studio.Bus MasterBus;
    FMOD.Studio.EventInstance Amb;

    // Start is called before the first frame update
    void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Amb = FMODUnity.RuntimeManager.CreateInstance("event:/Cutscene Ambiance");
        Amb.start();
        Amb.release();
    }
}
