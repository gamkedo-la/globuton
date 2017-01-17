using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource m_sfxSingleSource;
    public AudioSource m_sfxLoopSource;
    public AudioSource m_musicSource;
    public AudioSource m_securityCamSource;
    public static SoundManager instance = null;

    public AudioClip m_stingPuzzle;
    public AudioClip m_stingPickup;
    public AudioClip m_doorOpen;
    public AudioClip m_flies;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void PlaySingle(AudioClip clip)
    {
        m_sfxSingleSource.loop = false;
        m_sfxSingleSource.clip = clip;
        m_sfxSingleSource.Play();
    }

    public void PlayLoop(AudioClip clip)
    {
        m_sfxLoopSource.loop = true;
        m_sfxLoopSource.clip = clip;
        m_sfxLoopSource.Play();
    }

    public void StopSingle(AudioClip clip)
    {
        m_sfxSingleSource.clip = clip;
        m_sfxSingleSource.Stop();
    }

    public void StopLoop(AudioClip clip)
    {
        m_sfxLoopSource.clip = clip;
        m_sfxLoopSource.Stop();
    }

    public void StartMusic()
    {
        m_musicSource.Play();
    }
}