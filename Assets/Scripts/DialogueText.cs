using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour {
    public string objectDescription;
    private GameObject playerRef;

    void Start()
    {
        playerRef = GameObject.Find("Boxii");
    }
    //Does nothing?
    public void textDisplay() {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = Color.red;
    }

    public void OnGUI() {
        GUI.Box(new Rect(playerRef.transform.position.x, playerRef.transform.position.y, 250, 50),objectDescription);
    }
}      
