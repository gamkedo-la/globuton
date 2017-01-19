using UnityEngine;
using System.Collections;

public class StopFlyAnimation : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem flies;

    void Start()
    {
        flies = GameObject.FindGameObjectWithTag("Flies").GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter()
    {
        Debug.Log("Flies should be stopped");
        flies.Pause();
    }
}

