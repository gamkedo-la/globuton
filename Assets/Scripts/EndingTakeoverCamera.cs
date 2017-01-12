using UnityEngine;
using System.Collections;

public class EndingTakeoverCamera : MonoBehaviour {
    public GameObject turnOffCharacter;

	// Use this for initialization
	public void endGame () {
        turnOffCharacter.SetActive(false);
        Camera.main.transform.position = transform.position;
        Camera.main.transform.rotation = transform.rotation;
    }
	
}
