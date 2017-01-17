using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource m_sfxSource;
    public AudioSource m_musicSource;
    public AudioSource m_securityCamSource;
    public static SoundManager instance = null;

    public AudioClip m_stingPuzzle;
    public AudioClip m_stingPickup;
    public AudioClip m_doorOpen;


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
        m_sfxSource.loop = false;
        m_sfxSource.clip = clip;
        m_sfxSource.Play();
    }

    public void PlayLoop(AudioClip clip)
    {
        m_sfxSource.loop = true;
        m_sfxSource.clip = clip;
        m_sfxSource.Play();
    }
}