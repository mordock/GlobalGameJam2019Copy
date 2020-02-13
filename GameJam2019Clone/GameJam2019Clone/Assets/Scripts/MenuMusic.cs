using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    FMOD.Studio.EventInstance music;
    FMOD.Studio.EventInstance ambiance;

    // Start is called before the first frame update
    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Menu Music");
        ambiance = FMODUnity.RuntimeManager.CreateInstance("event:/Menu Ambiance");
        music.start();
        ambiance.start();
        music.release();
        ambiance.release();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
