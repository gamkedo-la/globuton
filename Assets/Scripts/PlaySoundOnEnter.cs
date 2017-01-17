using UnityEngine;
using System.Collections;

public class PlaySoundOnEnter : MonoBehaviour 
{
    public AudioClip soundToPlay;
    void OnTriggerEnter()
    {
        SoundManager.instance.PlaySingle(soundToPlay);
        Debug.Log("You are at the main door!"); 
    }

}
