using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ConfirmSound : MonoBehaviour
{
    public string EventPath;
    FMOD.Studio.EventInstance Click;

    // Start is called before the first frame update
    public void PlaySound()
    {
        Click = FMODUnity.RuntimeManager.CreateInstance(EventPath);
        Click.start();
        Click.release();
    }

    private void OnDestroy()
    {
        Click.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
   
}
