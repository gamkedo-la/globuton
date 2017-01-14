using UnityEngine;
using System.Collections;

public class EndingTakeoverCamera : MonoBehaviour {
	public ClickToMove turnOffCharacter;
	public static bool isPlaying = false;

	// Use this for initialization
	public void endGame () {
		isPlaying = true;
		turnOffCharacter.enabled = false;
        //Camera.main.transform.position = transform.position;
        //Camera.main.transform.rotation = transform.rotation;
		gameObject.GetComponent<Cutscene>().enabled = true;
    }
	
}
