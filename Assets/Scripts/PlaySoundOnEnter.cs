using UnityEngine;
using System.Collections;

public class PlaySoundOnEnter : MonoBehaviour 
{
    public AudioClip soundToPlay;
    public bool isLooping;

    void OnTriggerEnter()
    {
        if (this.isLooping)
        {
            SoundManager.instance.PlayLoop(soundToPlay);
        }
        else
        {
            SoundManager.instance.PlaySingle(soundToPlay);
        }
    }

    void OnTriggerExit()
    {
        if (this.isLooping)
        {
            SoundManager.instance.StopLoop(soundToPlay);
        }
        else
        {
            SoundManager.instance.StopSingle(soundToPlay);
        }
    }
}
