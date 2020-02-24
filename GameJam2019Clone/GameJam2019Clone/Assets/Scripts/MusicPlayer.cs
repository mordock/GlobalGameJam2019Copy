using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static FMOD.Studio.EventInstance music;
    FMOD.Studio.Bus MasterBus;


    // Start is called before the first frame update
    private void Awake()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

    }
    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Gameplay Music");
        music.start();
        music.release();
    }

    // Update is called once per frame
    void OnDestroy()
    {
        music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
